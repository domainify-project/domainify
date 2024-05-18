

namespace Domainify.Domain
{
    /// <summary>
    /// Represents an invariant request for a specific entity type by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the invariant request.</typeparam>
    /// <typeparam name="IdType">The type of the identifier for the entity.</typeparam>
    public abstract class InvariantRequestById<TEntity, IdType> :
        InvariantRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantRequestById{TEntity, IdType}"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        public InvariantRequestById(
            IdType id)
        {
            Id = id;
        }

        /// <summary>
        /// Sets the identifier of the entity.
        /// </summary>
        /// <param name="value">The value to set as the identifier.</param>
        /// <returns>The current instance of the invariant request for fluent chaining.</returns>
        public virtual InvariantRequestById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
