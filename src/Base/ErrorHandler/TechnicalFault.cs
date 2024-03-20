namespace Domainify
{
    /// <summary>
    /// Represents a technical fault associated with errors in the application.
    /// </summary>
    public class TechnicalFault : IFault
    {
        /// <summary>
        /// Gets or sets the name of the technical fault.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the technical fault.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
