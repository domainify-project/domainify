using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;
using Moq;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class BaseQueryRequestTests
    {
        public class TestQueryRequest : BaseQueryRequest<string> { }

        [TestMethod]
        public void Setup_Should_Set_PaginationSetting()
        {
            // Arrange
            var queryRequest = new TestQueryRequest();
            var paginationSetting = new PaginationSetting(2, 30);

            // Act
            queryRequest.Setup(paginationSetting);

            // Assert
            queryRequest.PaginationSetting.Should().Be(paginationSetting);
            queryRequest.PageNumber.Should().Be(paginationSetting.DefaultPageNumber);
            queryRequest.PageSize.Should().Be(paginationSetting.DefaultPageSize);
        }
    }
}
