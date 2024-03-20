using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class ValidationIssueTests
    {
        [TestMethod]
        public void Constructor_Should_Set_Name()
        {
            // Arrange & Act
            var validationIssue = new ValidationFault();

            // Assert
            validationIssue.Name.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Constructor_Should_Set_Default_Description()
        {
            // Arrange & Act
            var validationIssue = new ValidationFault();

            // Assert
            validationIssue.Description.Should().Be("A validation error has happened.");
        }

        [TestMethod]
        public void Constructor_Should_Set_Outer_Description()
        {
            // Arrange
            var outerDescription = "Outer description";

            // Act
            var validationIssue = new ValidationFault(outerDescription);

            // Assert
            validationIssue.Description.Should().Be(outerDescription);
        }

        [TestMethod]
        public void Constructor_Should_Set_Inner_Description()
        {
            // Arrange
            var innerDescription = "Inner description";

            // Act
            var validationIssue = new ValidationFault(innerDescription: innerDescription);

            // Assert
            validationIssue.Description.Should().Be(innerDescription);
        }

        [TestMethod]
        public void Constructor_Should_Set_Outer_And_Inner_Descriptions()
        {
            // Arrange
            var outerDescription = "Outer description";
            var innerDescription = "Inner description";

            // Act
            var validationIssue = new ValidationFault(outerDescription, innerDescription);

            // Assert
            validationIssue.Description.Should().Be(outerDescription);
        }
    }
}
