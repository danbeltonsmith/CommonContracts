using CommonContracts.Shared;
using FluentAssertions;

namespace CommonContracts.Tests.Shared
{
    public class PagedResultTests
    {
        [Fact]
        public void Items_DefaultConstructed_IsNeverNull()
        {
            // Arrange
            var result = new PagedResult<string>();

            // Act
            var items = result.Items;

            // Assert
            items.Should().NotBeNull();
            items.Should().BeEmpty();
        }

        [Fact]
        public void TotalPages_ExactMultipleOfPageSize_ReturnsExactQuotient()
        {
            // Arrange
            var result = new PagedResult<string> { PageSize = 10, TotalCount = 30 };

            // Act
            int totalPages = result.TotalPages;

            // Assert
            totalPages.Should().Be(3);
        }

        [Fact]
        public void TotalPages_PartialFinalPage_RoundsUp()
        {
            // Arrange
            var result = new PagedResult<string> { PageSize = 10, TotalCount = 25 };

            // Act
            int totalPages = result.TotalPages;

            // Assert
            totalPages.Should().Be(3);
        }

        [Fact]
        public void TotalPages_ZeroTotalCount_ReturnsZero()
        {
            // Arrange
            var result = new PagedResult<string> { PageSize = 10, TotalCount = 0 };

            // Act
            int totalPages = result.TotalPages;

            // Assert
            totalPages.Should().Be(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void TotalPages_ZeroOrNegativePageSize_ReturnsZeroWithoutThrowing(int pageSize)
        {
            // Arrange
            var result = new PagedResult<string> { PageSize = pageSize, TotalCount = 100 };

            // Act
            int totalPages = result.TotalPages;

            // Assert
            totalPages.Should().Be(0);
        }
    }
}
