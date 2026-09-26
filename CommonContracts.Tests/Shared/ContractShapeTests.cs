using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;
using CommonContracts.Movements;
using CommonContracts.Shared;
using FluentAssertions;

namespace CommonContracts.Tests.Shared
{
    public class ContractShapeTests
    {
        private static readonly JsonSerializerOptions WebOptions = new(JsonSerializerDefaults.Web);

        private static List<string> PropertyNames(object value)
        {
            using var document = JsonDocument.Parse(JsonSerializer.Serialize(value, WebOptions));
            return document.RootElement.EnumerateObject().Select(p => p.Name).OrderBy(n => n, StringComparer.Ordinal).ToList();
        }

        [Fact]
        public void PagedResultOfMovementSummary_SerialisesWithTheMovementSearchResponsePropertyNames()
        {
            // Arrange
            var pagedResult = new PagedResult<MovementSummary> { PageNumber = 2, PageSize = 25, TotalCount = 60 };

            // Act
            var names = PropertyNames(pagedResult);

            // Assert
            names.Should().Equal("items", "pageNumber", "pageSize", "totalCount", "totalPages");
        }

        [Fact]
        public void MovementSummary_SerialisesStatusAsIdAndName_AndLocationsWithADisplayName()
        {
            // Arrange
            var location = new LocationReference { ID = 10, Name = "Bellbowrie", DisplayName = "BELLBOWRIE, 4070", CountryCode = "AUS" };
            var summary = new MovementSummary
            {
                ID = 1,
                MovementNumber = "MOV0000001",
                Date = DateTimeOffset.UnixEpoch,
                Status = new LookupValue { ID = 2, Name = "In Transit" },
                Origin = location,
                Destination = location,
                InternalPilotEscorts = 0,
                ExternalPilotEscorts = 0,
                PoliceEscorts = 0,
                HighLoadEscorts = 0,
                Active = true,
                CreatedBy = new AuditUser { ID = 1, DisplayName = "Test User" },
                CreatedDate = DateTimeOffset.UnixEpoch,
                RowVersion = [1]
            };

            // Act
            using var document = JsonDocument.Parse(JsonSerializer.Serialize(summary, WebOptions));
            var root = document.RootElement;

            // Assert
            root.GetProperty("status").EnumerateObject().Select(p => p.Name).Should().Equal("id", "name");
            root.GetProperty("origin").GetProperty("displayName").GetString().Should().Be("BELLBOWRIE, 4070");
            root.GetProperty("createdBy").GetProperty("displayName").GetString().Should().Be("Test User");
        }

        [Fact]
        public void ApiError_SerialisesToTheBodyTheEnterpriseApiReturnsForAValidationFailure()
        {
            // Arrange
            var timestamp = new DateTime(2026, 9, 26, 7, 30, 0, DateTimeKind.Utc);
            List<ValidationErrorDetail> details = [new("Movements[0].StatusID", "Status ID must be greater than 0.")];

            var apiError = new ApiError
            {
                Message = "Validation failed",
                ErrorCode = "VALIDATION_ERROR",
                Details = details,
                Status = 400,
                Timestamp = timestamp
            };

            var todaysBody = new
            {
                message = "Validation failed",
                errorCode = "VALIDATION_ERROR",
                details,
                status = 400,
                timestamp
            };

            // Act
            var sharedJson = JsonSerializer.Serialize(apiError, WebOptions);
            var todaysJson = JsonSerializer.Serialize(todaysBody, WebOptions);

            // Assert
            sharedJson.Should().Be(todaysJson);
        }

        [Fact]
        public void MovementSearchRequest_IsAPagedSearchRequest_WithMovementsDefaults()
        {
            // Act
            PagedSearchRequest request = new MovementSearchRequest();

            // Assert
            request.PageNumber.Should().Be(1);
            request.PageSize.Should().Be(25);
            request.SearchValue.Should().BeNull();
        }

        [Fact]
        public void ContractsAssembly_ReferencesOnlyTheFramework()
        {
            // Act
            var references = typeof(AuditUser).Assembly.GetReferencedAssemblies().Select(a => a.Name!).ToList();

            // Assert
            references.Should().OnlyContain(name => name.StartsWith("System", StringComparison.Ordinal) || name == "netstandard" || name == "mscorlib");
        }

        private static string ContractsProjectPath([CallerFilePath] string thisFile = "")
            => Path.GetFullPath(Path.Combine(Path.GetDirectoryName(thisFile)!, "..", "..", "CommonContracts", "CommonContracts.csproj"));

        [Fact]
        public void ContractsProject_DeclaresNoPackageOrProjectReferences()
        {
            // Arrange
            var project = XDocument.Load(ContractsProjectPath());

            // Act
            var references = project.Descendants()
                .Where(e => e.Name.LocalName is "PackageReference" or "ProjectReference" or "Reference" or "FrameworkReference")
                .Select(e => (string?)e.Attribute("Include"))
                .ToList();

            // Assert
            references.Should().BeEmpty();
        }
    }
}
