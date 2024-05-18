using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Domainify.Domain;

namespace Domainify.Test.Domain
{
    // Mock implementation of IFault for testing
    public class MockFault : IFault
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    // Mock implementation of FieldValidationAttribute for testing
    public class MockFieldValidationAttribute : FieldValidationAttribute
    {
        public MockFieldValidationAttribute(string description) : base(description)
        {
        }

        public override bool IsValid(object? value)
        {
            return value != null && value.ToString() != "InvalidValue";
        }
    }

    // Mock implementation of BindToAttribute for testing
    public class MockBindToAttribute : BindToAttribute
    {
        public MockBindToAttribute(Type targetType, string targetPropertyName) : base(targetType, targetPropertyName)
        {
        }
    }

    // Mock implementation of BaseRequest for testing
    public class MockBaseRequest : BaseRequest
    {
        public string PropertyNameWithValidation { get; set; }
        public string PropertyNameWithBinding { get; set; }
    }

    [TestClass]
    public class ValidationStateTests
    {
        [TestMethod]
        public void AddAValidation_Should_Add_Validation_To_List()
        {
            // Arrange
            var validationState = new ValidationState<MockBaseRequest>(new MockBaseRequest());
            var validation = new Mock<Validation>().Object;

            // Act
            validationState.AddAValidation(validation);

            // Assert
            validationState.GetValidations().Should().Contain(validation);
        }

        [TestMethod]
        public void DefineAValidation_With_True_Condition_Should_Add_Fault_To_List()
        {
            // Arrange
            var validationState = new ValidationState<MockBaseRequest>(new MockBaseRequest());
            var fault = new MockFault();

            // Act
            validationState.DefineAValidation(true, fault);

            // Assert
            validationState.GetFaults().Should().Contain(fault);
        }

        [TestMethod]
        public void DefineAValidation_With_False_Condition_Should_Not_Add_Fault_To_List()
        {
            // Arrange
            var validationState = new ValidationState<MockBaseRequest>(new MockBaseRequest());
            var fault = new MockFault();

            // Act
            validationState.DefineAValidation(false, fault);

            // Assert
            validationState.GetFaults().Should().BeEmpty();
        }

        [TestMethod]
        public void DefineAValidation_With_True_Condition_Function_Should_Add_Fault_To_List()
        {
            // Arrange
            var validationState = new ValidationState<MockBaseRequest>(new MockBaseRequest());
            var fault = new MockFault();

            // Act
            validationState.DefineAValidation(() => true, fault);

            // Assert
            validationState.GetFaults().Should().Contain(fault);
        }

        [TestMethod]
        public void DefineAValidation_With_False_Condition_Function_Should_Not_Add_Fault_To_List()
        {
            // Arrange
            var validationState = new ValidationState<MockBaseRequest>(new MockBaseRequest());
            var fault = new MockFault();

            // Act
            validationState.DefineAValidation(() => false, fault);

            // Assert
            validationState.GetFaults().Should().BeEmpty();
        }
    }
}