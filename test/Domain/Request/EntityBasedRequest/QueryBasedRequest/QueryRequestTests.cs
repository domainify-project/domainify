using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;

namespace Domainify.Test.Domain
{
    public class TestEntity : Entity<TestEntity, Guid>, IAggregateRoot
    {
        public double Version { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class TestQueryRequest : QueryRequest<TestEntity>
    {
    }
    [TestClass]
    public class QueryRequestTests
    {
        [TestMethod]
        public void Setup_Should_Set_Pagination_Settings_If_PaginationSetting_Is_Provided()
        {
            // Arrange
            var queryRequest = new TestQueryRequest();
            var paginationSetting = new PaginationSetting(
                defaultPageNumber: 1, defaultPageSize: 10);

            // Act
            queryRequest.Setup(paginationSetting);

            // Assert
            Assert.AreEqual(1, queryRequest.PageNumber);
            Assert.AreEqual(10, queryRequest.PageSize);
        }
    }
}
