

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a logical fault in the domain model.
    /// </summary>
    public class LogicalFault : IFault
    {
        /// <summary>
        /// Gets or sets the name of the logical fault.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the logical fault.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicalFault"/> class with the specified descriptions.
        /// </summary>
        /// <param name="outerDescription">The outer description of the logical fault.</param>
        /// <param name="innerDescription">The inner description of the logical fault.</param>
        public LogicalFault(
            string outerDescription,
            string innerDescription)
        {
            // Set the name of the logical fault to the full type name.
            Name = GetType().FullName!;

            // Determine the description based on the provided parameters.
            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = "A logical error has happened.";
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
