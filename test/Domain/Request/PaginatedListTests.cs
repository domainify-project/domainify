using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class PaginatedListTests
    {
        [TestMethod]
        public void PaginatedList_ShouldCalculateTotalPagesCorrectly()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageSize = 2;
            var paginatedList = new PaginatedList<int>(items, numberOfTotalItems, pageSize: pageSize);

            // Act

            // Assert
            paginatedList.TotalPages.Should().Be((int)Math.Ceiling(numberOfTotalItems / (double)pageSize));
        }

        [TestMethod]
        public void PaginatedList_HasPreviousPage_ShouldReturnTrueWhenPageNumberIsGreaterThanOne()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageNumber = 2;
            var paginatedList = new PaginatedList<int>(items, numberOfTotalItems, pageNumber: pageNumber);

            // Act

            // Assert
            paginatedList.HasPreviousPage.Should().BeTrue();
        }

        [TestMethod]
        public void PaginatedList_HasPreviousPage_ShouldReturnFalseWhenPageNumberIsOne()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageNumber = 1;
            var paginatedList = new PaginatedList<int>(items, numberOfTotalItems, pageNumber: pageNumber);

            // Act

            // Assert
            paginatedList.HasPreviousPage.Should().BeFalse();
        }

        [TestMethod]
        public void PaginatedList_HasNextPage_ShouldReturnTrueWhenPageNumberIsLessThanTotalPages()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageNumber = 1;
            var pageSize = 2;
            var paginatedList = new PaginatedList<int>(items, numberOfTotalItems, pageNumber: pageNumber, pageSize: pageSize);

            // Act

            // Assert
            paginatedList.HasNextPage.Should().BeTrue();
        }

        [TestMethod]
        public void PaginatedList_HasNextPage_ShouldReturnFalseWhenPageNumberEqualsTotalPages()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageNumber = 3;
            var pageSize = 2;
            var paginatedList = new PaginatedList<int>(items, numberOfTotalItems, pageNumber: pageNumber, pageSize: pageSize);

            // Act

            // Assert
            paginatedList.HasNextPage.Should().BeFalse();
        }
    }
}
