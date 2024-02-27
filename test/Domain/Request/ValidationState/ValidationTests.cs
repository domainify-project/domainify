using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class ValidationTests
    {
        public class TestValidation : Validation
        {
            public override bool Resolve()
            {
                return true;
            }

            public override IIssue? GetIssue()
            {
                return null;
            }
        }

        [TestMethod]
        public void WithDescription_Should_Set_Description()
        {
            // Arrange
            var validation = new TestValidation();
            var description = "Test description";

            // Act
            validation.WithDescription(description);

            // Assert
            validation.Description.Should().Be(description);
        }
    }
}
