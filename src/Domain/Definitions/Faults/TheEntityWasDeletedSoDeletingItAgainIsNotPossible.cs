using System.Globalization;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents an fault where an attempt was made to delete an entity that has already been deleted.
    /// </summary>
    public class TheEntityWasDeletedSoDeletingItAgainIsNotPossible : InvariantFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheEntityWasDeletedSoDeletingItAgainIsNotPossible"/> class.
        /// </summary>
        /// <param name="entityName">The name of the entity that was attempted to be deleted.</param>
        /// <param name="description">A description of the fault.</param>
        public TheEntityWasDeletedSoDeletingItAgainIsNotPossible(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                 "The {0} entity has been deleted, so deleting it again is not possible."
                    , entityName))
        {
        }
    }
}
