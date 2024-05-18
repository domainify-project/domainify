using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class InvariantFaultTests
    {

        [TestMethod]
        public void Constructor_WithoutDescriptions_ShouldSetPropertiesWithDefaultDescriptions()
        {
            // Arrange

            // Act
            var invariantFault = new InvariantFault("", "");

            // Assert
            invariantFault.Name.Should().Be(typeof(InvariantFault).FullName);
            invariantFault.Description.Should().Be("An invariant error has happened.");
        }
    }
}
