﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class InvariantIssueTests
    {

        [TestMethod]
        public void Constructor_WithoutDescriptions_ShouldSetPropertiesWithDefaultDescriptions()
        {
            // Arrange

            // Act
            var invariantIssue = new InvariantFault("", "");

            // Assert
            invariantIssue.Name.Should().Be(typeof(InvariantFault).FullName);
            invariantIssue.Description.Should().Be("An invariant error has happened.");
        }
    }
}
