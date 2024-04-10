using System.Globalization;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a fault that occurs when attempting to delete an entity permanently without first deleting it.
    /// </summary>
    internal class EntityMustBeDeletedBeforeBenigDeletedPermanentlyFault : InvariantFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityMustBeDeletedBeforeBenigDeletedPermanentlyFault"/> class
        /// with the specified entity name and description.
        /// </summary>
        /// <param name="entityName">The name of the entity that must be deleted before being permanently deleted.</param>
        /// <param name="description">A description of the fault.</param>
        public EntityMustBeDeletedBeforeBenigDeletedPermanentlyFault(
            string entityName = "", string description = "") :
            base(outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "the entity must be deleted before being deleted permanently.",
                entityName))
        {
        }
    }
}
