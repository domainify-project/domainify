using System.Globalization;

namespace Domainify.Domain
{
    public class TheEntityIsNotAlreadyDeletedSoDeletingItPermanentlyIsNotPossible : InvariantIssue
    {
        public TheEntityIsNotAlreadyDeletedSoDeletingItPermanentlyIsNotPossible(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                 "The {0} entity is not already deleted, so deleting it permanently is not possible. At first the entity should be deleted, then deleting that permanently will be possible."
                    , entityName))
        {
        }
    }
}
