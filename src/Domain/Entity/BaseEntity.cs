namespace Domainify.Domain
{
    /// <summary>
    /// Represents a base entity with common properties and methods for entities in the domain model.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseEntity<TEntity>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is marked as isDeleted (soft delete).
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Gets or sets the date and time when the entity was last modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Creates the entity, setting the creation and modification dates.
        /// </summary>
        public virtual void Create()
        {
            ModifiedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the entity, setting the modification date.
        /// </summary>
        public virtual void Update()
        {
            ModifiedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Deletes the entity, setting the modification date.
        /// </summary>
        public virtual void Delete()
        {
            IsDeleted = true;
            ModifiedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Restores the entity, setting the modification date.
        /// </summary>
        public virtual void Restore()
        {
            IsDeleted = false;
            ModifiedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Deletes the entity permanently.
        /// </summary>
        public virtual void DeletePermanently()
        {
        }
    }
}
