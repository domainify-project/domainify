using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

using Domainify.Domain;

namespace Domainify.Test.Domain
{
    [TestClass]
    public class InvariantTests
    {
        public class TestModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [TestMethod]
        public void Constructor_Should_SetConditionAndFault()
        {
            // Arrange
            Expression<Func<TestModel, bool>> condition = model => model.Age >= 18;
            IFault fault = new InvariantFault("Invalid Age", string.Empty);

            // Act
            var invariant = new Invariant<TestModel>(condition, fault);

            // Assert
            invariant.Condition.Should().Be(condition);
            invariant.Fault.Should().Be(fault);
        }
    }
}
