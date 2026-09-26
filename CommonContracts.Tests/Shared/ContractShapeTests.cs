using System.Text.Json;
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
        public void PagedResultOfMovementSummary_SerialisesWithTheSamePropertyNamesAsMovementSearchResponse()
        {
            // Arrange
            var pagedResult = new PagedResult<MovementSummary> { PageNumber = 2, PageSize = 25, TotalCount = 60 };
#pragma warning disable CS0618
            var legacyResponse = new MovementSearchResponse { PageNumber = 2, PageSize = 25, TotalCount = 60, TotalPages = 3 };
#pragma warning restore CS0618

            // Act
            var sharedNames = PropertyNames(pagedResult);
            var legacyNames = PropertyNames(legacyResponse);

            // Assert
            sharedNames.Should().Equal(legacyNames);
            sharedNames.Should().Contain("totalPages");
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
    }
}
