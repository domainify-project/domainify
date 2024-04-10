using System.Globalization;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a fault where an attempt was made to restore an entity that has not been deleted.
    /// </summary>
    public class NoEntityWasDeletedSoRestoringItIsNotPossibleFault : InvariantFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoEntityWasDeletedSoRestoringItIsNotPossibleFault"/> class.
        /// </summary>
        /// <param name="entityName">The name of the entity that was attempted to be restored.</param>
        /// <param name="description">A description of the fault.</param>
        public NoEntityWasDeletedSoRestoringItIsNotPossibleFault(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "No {0} entity has not been deleted, so restoring it is not possible.",
                entityName))
        {
        }
    }
}
