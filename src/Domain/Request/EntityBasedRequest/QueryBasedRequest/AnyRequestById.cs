

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to determine if any entity of a specific type exists with the specified identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    /// <typeparam name="IdType">The type of the entity identifier.</typeparam>
    public abstract class AnyRequestById<TEntity, IdType> :
        AnyRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnyRequestById{TEntity, IdType}"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        public AnyRequestById(IdType id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the identifier of the entity for which existence is being determined.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Sets the identifier of the entity for which existence is being determined.
        /// </summary>
        /// <param name="value">The new value for the identifier.</param>
        /// <returns>The current instance of the request for fluent chaining.</returns>
        public virtual AnyRequestById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
