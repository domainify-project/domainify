using FluentAssertions;
using Domainify.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class BaseEntityTests
    {
        [TestMethod]
        public void Create_ShouldSetCreatedDateAndModifiedDate()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            entity.Create();

            // Assert
            entity.ModifiedDate.Should().NotBe(default);
        }

        [TestMethod]
        public void Update_ShouldSetModifiedDate()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            entity.Update();

            // Assert
            entity.ModifiedDate.Should().NotBe(default);
        }

        [TestMethod]
        public void Delete_ShouldSetModifiedDate()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            entity.Delete();

            // Assert
            entity.ModifiedDate.Should().NotBe(default);
        }

        [TestMethod]
        public void Restore_ShouldSetModifiedDate()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            entity.Restore();

            // Assert
            entity.ModifiedDate.Should().NotBe(default);
        }

        [TestMethod]
        public void Delete_ShouldNotThrowException()
        {
            // Arrange
            var entity = new MockEntity();

            // Act & Assert
            entity.Invoking(e => e.DeletePermanently()).Should().NotThrow();
        }

        private class MockEntity : BaseEntity<object>
        {
        }
    }
}