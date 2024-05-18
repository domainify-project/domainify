using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class LogicalFaultTests
    {
        [TestMethod]
        public void Constructor_WithOuterAndInnerDescription_ShouldSetDescriptionToOuterDescription()
        {
            // Arrange
            var outerDescription = "Outer Description";
            var innerDescription = "Inner Description";

            // Act
            var logicalFault = new LogicalFault(outerDescription, innerDescription);

            // Assert
            logicalFault.Description.Should().Be(outerDescription);
        }

        [TestMethod]
        public void Constructor_WithInnerDescriptionOnly_ShouldSetDescriptionToInnerDescription()
        {
            // Arrange
            var innerDescription = "Inner Description";

            // Act
            var logicalFault = new LogicalFault(string.Empty, innerDescription);

            // Assert
            logicalFault.Description.Should().Be(innerDescription);
        }

        [TestMethod]
        public void Constructor_WithOuterDescriptionOnly_ShouldSetDescriptionToOuterDescription()
        {
            // Arrange
            var outerDescription = "Outer Description";

            // Act
            var logicalFault = new LogicalFault(outerDescription, string.Empty);

            // Assert
            logicalFault.Description.Should().Be(outerDescription);
        }

        [TestMethod]
        public void Constructor_WithoutDescriptions_ShouldSetDefaultDescription()
        {
            // Act
            var logicalFault = new LogicalFault(string.Empty, string.Empty);

            // Assert
            logicalFault.Description.Should().Be("A logical error has happened.");
        }

        [TestMethod]
        public void Name_ShouldBeSetToFullTypeName()
        {
            // Act
            var logicalFault = new LogicalFault(string.Empty, string.Empty);

            // Assert
            logicalFault.Name.Should().Be(typeof(LogicalFault).FullName);
        }
    }
}
