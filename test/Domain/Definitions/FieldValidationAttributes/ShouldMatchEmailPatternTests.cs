using FluentAssertions;
using Domainify.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Domainify.Test.Domain
{
    [TestClass]
    public class ShouldMatchEmailPatternTests
    {
        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_ValueIsNull()
        {
            // Arrange
            var emailPatternAttribute = new ShouldMatchEmailPattern();

            // Act
            var isValid = emailPatternAttribute.IsValid(null);

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_ValueIsAValidEmailAddress()
        {
            // Arrange
            var emailPatternAttribute = new ShouldMatchEmailPattern();

            // Act
            var isValid = emailPatternAttribute.IsValid("test@example.com");

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnFalse_When_ValueIsNotAValidEmailAddress()
        {
            // Arrange
            var emailPatternAttribute = new ShouldMatchEmailPattern();

            // Act
            var isValid = emailPatternAttribute.IsValid("invalid-email");

            // Assert
            isValid.Should().BeFalse();
        }

        [TestMethod]
        public void Validate_Should_AddFault_When_ValidationFails()
        {
            // Arrange
            var emailPatternAttribute = new ShouldMatchEmailPattern();
            var faults = new List<IFault>();

            // Act
            emailPatternAttribute.Validate("invalid-email", faults);

            // Assert
            faults.Should().HaveCount(1);
            faults[0].Should().BeOfType<FieldIsNotAValidEamilAddressFault>();
        }

        [TestMethod]
        public void CreateRegExForMatchingStandardEmail_Should_NotThrowException()
        {
            // Arrange
            Action act = () => ShouldMatchEmailPattern.CreateRegExForMatchingStandardEmail();

            // Act and Assert
            act.Should().NotThrow();
        }
    }
}
