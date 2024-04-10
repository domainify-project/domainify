﻿using FluentAssertions;
using Domainify.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Domainify.Test.Domain
{
    [TestClass]
    public class MinLengthShouldBeAttributeTests
    {
        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_ValueIsNull()
        {
            // Arrange
            var minLengthAttribute = new MinLengthShouldBeAttribute(10);

            // Act
            var isValid = minLengthAttribute.IsValid(null);

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_StringLengthIsEqualOrGreaterThanLimit()
        {
            // Arrange
            var minLengthAttribute = new MinLengthShouldBeAttribute(5);

            // Act
            var isValid = minLengthAttribute.IsValid("12345");

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_ArrayLengthIsEqualOrGreaterThanLimit()
        {
            // Arrange
            var minLengthAttribute = new MinLengthShouldBeAttribute(3);

            // Act
            var isValid = minLengthAttribute.IsValid(new int[] { 1, 2, 3 });

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnFalse_When_StringLengthIsLessThanLimit()
        {
            // Arrange
            var minLengthAttribute = new MinLengthShouldBeAttribute(8);

            // Act
            var isValid = minLengthAttribute.IsValid("12345");

            // Assert
            isValid.Should().BeFalse();
        }

        [TestMethod]
        public void Validate_Should_AddIssue_When_ValidationFails()
        {
            // Arrange
            var minLengthAttribute = new MinLengthShouldBeAttribute(5);
            var faults = new List<IFault>();

            // Act
            minLengthAttribute.Validate("123", faults);

            // Assert
            faults.Should().HaveCount(1);
            faults[0].Should().BeOfType<FieldLengthIsLessThanMinimumLengthLimitFault>();
        }

        [TestMethod]
        public void EnsureLengthsIsAllowed_Should_ThrowException_When_LengthIsNegative()
        {
            // Arrange
            var minLengthAttribute = new MinLengthShouldBeAttribute(-1);

            // Act and Assert
            Action act = () => minLengthAttribute.Invoking(a => a.EnsureLengthsIsAllowed()).Should().Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void EnsureLengthsIsAllowed_Should_NotThrowException_When_LengthIsZeroOrGreater()
        {
            // Arrange
            var minLengthAttribute = new MinLengthShouldBeAttribute(5);

            // Act and Assert
            minLengthAttribute.Invoking(a => a.EnsureLengthsIsAllowed()).Should().NotThrow();
        }
    }
}
