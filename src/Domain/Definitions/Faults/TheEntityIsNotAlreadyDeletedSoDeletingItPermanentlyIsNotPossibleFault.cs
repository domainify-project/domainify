using System.Globalization;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a fault that occurs when attempting to delete an entity permanently that is not already deleted.
    /// </summary>
    public class TheEntityIsNotAlreadyDeletedSoDeletingItPermanentlyIsNotPossibleFault : InvariantFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheEntityIsNotAlreadyDeletedSoDeletingItPermanentlyIsNotPossibleFault"/> class
        /// with the specified entity name and description.
        /// </summary>
        /// <param name="entityName">The name of the entity that cannot be deleted permanently because it's not already deleted.</param>
        /// <param name="description">A description of the fault.</param>
        public TheEntityIsNotAlreadyDeletedSoDeletingItPermanentlyIsNotPossibleFault(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                 "The {0} entity is not already deleted, so deleting it permanently is not possible. At first the entity should be deleted, then deleting that permanently will be possible."
                    , entityName))
        {
        }
    }
}
