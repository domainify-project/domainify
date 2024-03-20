using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class LogicalIssueTests
    {
        [TestMethod]
        public void Constructor_WithOuterAndInnerDescription_ShouldSetDescriptionToOuterDescription()
        {
            // Arrange
            var outerDescription = "Outer Description";
            var innerDescription = "Inner Description";

            // Act
            var logicalIssue = new LogicalFault(outerDescription, innerDescription);

            // Assert
            logicalIssue.Description.Should().Be(outerDescription);
        }

        [TestMethod]
        public void Constructor_WithInnerDescriptionOnly_ShouldSetDescriptionToInnerDescription()
        {
            // Arrange
            var innerDescription = "Inner Description";

            // Act
            var logicalIssue = new LogicalFault(string.Empty, innerDescription);

            // Assert
            logicalIssue.Description.Should().Be(innerDescription);
        }

        [TestMethod]
        public void Constructor_WithOuterDescriptionOnly_ShouldSetDescriptionToOuterDescription()
        {
            // Arrange
            var outerDescription = "Outer Description";

            // Act
            var logicalIssue = new LogicalFault(outerDescription, string.Empty);

            // Assert
            logicalIssue.Description.Should().Be(outerDescription);
        }

        [TestMethod]
        public void Constructor_WithoutDescriptions_ShouldSetDefaultDescription()
        {
            // Act
            var logicalIssue = new LogicalFault(string.Empty, string.Empty);

            // Assert
            logicalIssue.Description.Should().Be("A logical error has happened.");
        }

        [TestMethod]
        public void Name_ShouldBeSetToFullTypeName()
        {
            // Act
            var logicalIssue = new LogicalFault(string.Empty, string.Empty);

            // Assert
            logicalIssue.Name.Should().Be(typeof(LogicalFault).FullName);
        }
    }
}
