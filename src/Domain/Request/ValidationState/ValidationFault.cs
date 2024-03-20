

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a validation fault in the domain model.
    /// </summary>
    public class ValidationFault : IFault
    {
        /// <summary>
        /// Gets or sets the name of the validation fault.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the validation fault.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFault"/> class with optional descriptions.
        /// </summary>
        /// <param name="outerDescription">The outer description of the validation fault.</param>
        /// <param name="innerDescription">The inner description of the validation fault.</param>
        public ValidationFault(
            string outerDescription = "",
            string innerDescription = "")
        {
            // Set the name of the validation fault to the full type name.
            Name = GetType().FullName!;

            // Determine the description based on the provided parameters.
            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = "A validation error has happened.";
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
