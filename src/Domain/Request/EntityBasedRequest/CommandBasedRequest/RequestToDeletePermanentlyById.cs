using System.Linq.Expressions;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to permanently delete an entity by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to permanently delete.</typeparam>
    /// <typeparam name="IdType">The type of the entity's identifier.</typeparam>
    public abstract class RequestToDeletePermanentlyById<TEntity, IdType> :
        RequestToDeletePermanently<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestToDeletePermanentlyById{TEntity, IdType}"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity to permanently delete.</param>
        public RequestToDeletePermanentlyById(IdType id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier of the entity to permanently delete.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Returns an expression to identify the entity to permanently delete based on its identifier.
        /// </summary>
        /// <returns>An expression representing the identification of the entity.</returns>
        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }

        /// <summary>
        /// Sets the identifier of the entity to permanently delete.
        /// </summary>
        /// <param name="value">The new identifier value.</param>
        /// <returns>The current instance of <see cref="RequestToDeletePermanentlyById{TEntity, IdType}"/>.</returns>
        public virtual RequestToDeletePermanentlyById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
