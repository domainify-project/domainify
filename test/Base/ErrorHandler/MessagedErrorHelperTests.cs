using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domainify.Domain;

namespace Domainify.Test
{
    public class ValidationA : ValidationFault
    {
        public ValidationA(
            string entityName = "",
            string description = "Description of Validation A") :
            base(outerDescription: description)
        {
        }
    }
    public class ValidationB : ValidationFault
    {
        public ValidationB(
            string entityName = "",
            string description = "Description of Validation B") :
            base(outerDescription: description)
        {
        }
    }

    [TestClass]
    public class MessagedErrorHelperTests
    {
        //[TestMethod]
        //public void RetrieveError_ShouldReturnError_WhenValidSerializedErrorProvided()
        //{
        //    var faults = new List<BaseFault>
        //    {
        //        new ValidationA (),
        //        new ValidationB ()
        //    };

        //    var error = new Error(
        //        service: "TestService",
        //        errorType: ErrorType.Validation,
        //        faults: faults);

        //    var errorMessage = MessagedErrorHelper.ConvertToErrorMessage(error);

        //    // Act
        //    var retrievedError = MessagedErrorHelper.RetrieceError(errorMessage);

        //    // Assert
        //    retrievedError.Should().NotBeNull();
        //    retrievedError!.ErrorType.Should().Be(ErrorType.Validation);
        //    retrievedError.Faults.Should().HaveCount(2);
        //    retrievedError.Faults.Should().Contain(fault => fault.Name == "Domainify.Test.ErrorHandler.ValidationA" && fault.Description == "Description of Validation A");
        //    retrievedError.Faults.Should().Contain(fault => fault.Name == "Domainify.Test.ErrorHandler.ValidationB" && fault.Description == "Description of Validation B");
        //}

        [TestMethod]
        public void RetrieveError_ShouldReturnNull_WhenInvalidSerializedErrorProvided()
        {
            // Arrange
            var invalidErrorMessage = "This is not a valid error message.";

            // Act
            var retrievedError = MessagedErrorHelper.RetrieceError(invalidErrorMessage);

            // Assert
            retrievedError.Should().BeNull();
        }

        [TestMethod]
        public void IsErrorException_ShouldReturnTrue_WhenValidSerializedErrorProvided()
        {
            // Arrange
            var faults = new List<IFault>
            {
                new ValidationA (),
                new ValidationB ()
            };

            var error = new Error(
                service: "TestService",
                errorType: ErrorType.Validation,
                faults: faults);

            var errorMessage = MessagedErrorHelper.ConvertToErrorMessage(error);

            // Act
            var isErrorException = MessagedErrorHelper.IsErrorException(errorMessage);

            // Assert
            isErrorException.Should().BeTrue();
        }

        [TestMethod]
        public void IsErrorException_ShouldReturnFalse_WhenInvalidSerializedErrorProvided()
        {
            // Arrange
            var invalidErrorMessage = "This is not a valid error message.";

            // Act
            var isErrorException = MessagedErrorHelper.IsErrorException(invalidErrorMessage);

            // Assert
            isErrorException.Should().BeFalse();
        }
    }
}
