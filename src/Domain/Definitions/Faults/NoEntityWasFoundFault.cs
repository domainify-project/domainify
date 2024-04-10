using System.Globalization;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a fault that occurs when no entity with the specified criteria is found.
    /// </summary>
    public class NoEntityWasFoundFault : InvariantFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoEntityWasFoundFault"/> class
        /// with the specified entity name and description.
        /// </summary>
        /// <param name="entityName">The name of the entity that was not found.</param>
        /// <param name="description">A custom description for the invariant fault (optional).</param>
        public NoEntityWasFoundFault(string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "No {0} entity was found.", entityName))
        {
        }
    }
}