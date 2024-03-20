

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a invariant fault in the domain model.
    /// </summary>
    public class InvariantFault : IFault
    {
        /// <summary>
        /// Gets or sets the name of the invariant fault.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the invariant fault.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantFault"/> class with optional descriptions.
        /// </summary>
        /// <param name="outerDescription">The outer description of the invariant fault.</param>
        /// <param name="innerDescription">The inner description of the invariant fault.</param>
        public InvariantFault(
            string outerDescription,
            string innerDescription)
        {
            // Set the name of the invariant fault to the full type name.
            Name = GetType().FullName!;

            // Determine the description based on the provided parameters.
            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = "An invariant error has happened.";
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
