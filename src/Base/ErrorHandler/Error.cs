using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domainify
{
    /// <summary>
    /// Represents an error in the application, containing information about the service, error type, faults, and a request ID.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="service">The name of the service where the error occurred.</param>
        /// <param name="errorType">The type of the error.</param>
        /// <param name="faults">A list of faults associated with the error.</param>
        public Error(
            string service,
            ErrorType errorType,
            List<IFault> faults)
        {
            Service = service;
            ErrorType = errorType;
            Faults = faults;
        }

        /// <summary>
        /// Gets or sets the request ID associated with the error.
        /// </summary>
        [DataMember(Order = 1)]
        public virtual string? RequestId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service where the error occurred.
        /// </summary>
        [DataMember(Order = 2)]
        public virtual string Service { get; set; }

        /// <summary>
        /// Gets the string representation of the error type.
        /// </summary>
        [DataMember(Order = 3)]
        public virtual string Type { get { return ErrorType.ToString(); } }

        /// <summary>
        /// Gets or sets the list of faults associated with the error.
        /// </summary>
        [DataMember(Order = 4)]
        public virtual List<IFault> Faults { get; set; }

        /// <summary>
        /// Gets or sets the error type.
        /// </summary>
        [JsonIgnore]
        public virtual ErrorType ErrorType { get; set; }
    }
}
