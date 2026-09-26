using System.Reflection;
using System.Runtime.CompilerServices;
using CommonContracts.Jobs;
using CommonContracts.Shared;
using FluentAssertions;

namespace CommonContracts.Tests.Jobs
{
    public class JobContractTests
    {
        private static readonly Type[] JobContracts = typeof(Job).Assembly.GetTypes()
            .Where(type => type.Namespace == "CommonContracts.Jobs" && type.IsPublic)
            .ToArray();

        private static IEnumerable<PropertyInfo> PropertiesOf(Type type) => type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        [Fact]
        public void NoJobContract_RepresentsALookupAsAnEnum()
        {
            JobContracts.SelectMany(PropertiesOf)
                .Where(property => (Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType).IsEnum)
                .Should().BeEmpty();
        }

        [Fact]
        public void NoJobContract_ExposesMoreOfAUserThanTheSharedAuditUser()
        {
            JobContracts.SelectMany(PropertiesOf)
                .Where(property => property.PropertyType.Name.Contains("User") && property.PropertyType != typeof(AuditUser))
                .Should().BeEmpty();
        }

        [Fact]
        public void NoJobRequest_AcceptsAuditFields()
        {
            var auditNames = new[] { "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate" };

            JobContracts.Where(type => type.Name.EndsWith("Request", StringComparison.Ordinal))
                .SelectMany(PropertiesOf)
                .Where(property => auditNames.Contains(property.Name))
                .Should().BeEmpty();
        }

        [Fact]
        public void SaveJobRequest_HasNoChargeAmount()
        {
            typeof(SaveJobRequest).GetProperty("ChargeAmount").Should().BeNull();
        }

        [Fact]
        public void ExistingJobMovementRequest_RequiresTheRowVersionTheCallerRead()
        {
            var rowVersion = typeof(ExistingJobMovementRequest).GetProperty(nameof(ExistingJobMovementRequest.RowVersion))!;

            rowVersion.GetCustomAttribute<RequiredMemberAttribute>().Should().NotBeNull();
            typeof(NewJobMovementRequest).GetProperty("RowVersion").Should().BeNull();
        }

        [Fact]
        public void JobSearchRequest_IsAPagedSearchRequest()
        {
            PagedSearchRequest request = new JobSearchRequest();

            request.PageNumber.Should().Be(1);
            request.PageSize.Should().Be(25);
        }
    }
}
