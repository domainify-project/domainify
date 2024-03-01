using System.Globalization;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents an issue where an attempt was made to restore an entity that has not been deleted.
    /// </summary>
    public class NoEntityWasDeletedSoRestoringItIsNotPossible : InvariantIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoEntityWasDeletedSoRestoringItIsNotPossible"/> class.
        /// </summary>
        /// <param name="entityName">The name of the entity that was attempted to be restored.</param>
        /// <param name="description">A description of the issue.</param>
        public NoEntityWasDeletedSoRestoringItIsNotPossible(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "No {0} entity has not been deleted, so restoring it is not possible.",
                entityName))
        {
        }
    }
}
