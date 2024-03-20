﻿using FluentAssertions;
using Domainify.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class PreventIfStartDateIsLaterThanEndDateTests
    {
        [TestMethod]
        public void Resolve_Should_ReturnFalse_When_StartDateIsNotLaterThanEndDate()
        {
            // Arrange
            var startDate = new DateTime(2023, 1, 1);
            var endDate = new DateTime(2023, 1, 2);
            var validationRule = new PreventIfStartDateIsLaterThanEndDate<TestEntity>(startDate, endDate);

            // Act
            var result = validationRule.Resolve();

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Resolve_Should_ReturnTrue_When_StartDateIsLaterThanEndDate()
        {
            // Arrange
            var startDate = new DateTime(2023, 1, 2);
            var endDate = new DateTime(2023, 1, 1);
            var validationRule = new PreventIfStartDateIsLaterThanEndDate<TestEntity>(startDate, endDate);

            // Act
            var result = validationRule.Resolve();

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void GetIssue_Should_ReturnNull_When_StartDateIsNotLaterThanEndDate()
        {
            // Arrange
            var startDate = new DateTime(2023, 1, 1);
            var endDate = new DateTime(2023, 1, 2);
            var validationRule = new PreventIfStartDateIsLaterThanEndDate<TestEntity>(startDate, endDate);

            // Act
            var fault = validationRule.GetFault();

            // Assert
            fault.Should().BeNull();
        }

        [TestMethod]
        public void GetIssue_Should_ReturnIssue_When_StartDateIsLaterThanEndDate()
        {
            // Arrange
            var startDate = new DateTime(2023, 1, 2);
            var endDate = new DateTime(2023, 1, 1);
            var validationRule = new PreventIfStartDateIsLaterThanEndDate<TestEntity>(startDate, endDate);

            // Act
            var fault = validationRule.GetFault();

            // Assert
            fault.Should().NotBeNull();
            fault.Should().BeOfType<StartDateCanNotBeLaterThanEndDate>();
        }
    }
}
