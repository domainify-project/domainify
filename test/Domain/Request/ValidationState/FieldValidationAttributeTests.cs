using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class FieldValidationAttributeTests
    {
        public class TestFieldValidationAttribute : FieldValidationAttribute
        {
            public TestFieldValidationAttribute() : base() { }
            public TestFieldValidationAttribute(string description) : base(description) { }

            public override bool IsValid(object? value)
            {
                return true;
            }

            public override void Validate(object? value, ICollection<IFault> faults, string propertyName = "")
            {
            }
        }

        [TestMethod]
        public void Constructor_Should_Set_Description()
        {
            // Arrange
            var description = "Test description";

            // Act
            var validationAttribute = new TestFieldValidationAttribute(description);

            // Assert
            validationAttribute.Description.Should().Be(description);
        }
    }
}
