using System.Globalization;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a fault that occurs when an entity with specified properties already exists.
    /// </summary>
    public class AnEntityWithThesePropertiesHasAlreadyExistedFault : InvariantFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnEntityWithThesePropertiesHasAlreadyExistedFault"/> class with specified parameters.
        /// </summary>
        /// <param name="entityName">The name of the entity causing the fault.</param>
        /// <param name="description">The description of the fault.</param>
        public AnEntityWithThesePropertiesHasAlreadyExistedFault(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "An {0} entity with these properties has already existed.",
                entityName))
        {
        }
    }
}