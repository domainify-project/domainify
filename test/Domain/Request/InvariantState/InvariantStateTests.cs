using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domainify.Domain;

namespace Domainify.Test.Domain
{

    [TestClass]
    public class InvariantStateTests
    {
        private class TestEntity : Entity<TestEntity, Guid>, IAggregateRoot
        {
            public double Version { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }

        [TestMethod]
        public async Task AssestAsync_NoIssues_ShouldNotThrowException()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var invariantState = new InvariantState<TestEntity>();

            // Act
            await invariantState.AssestAsync(mediatorMock.Object);

            // Assert
            invariantState.GetFaults().Should().BeEmpty();
        }
    }
}
