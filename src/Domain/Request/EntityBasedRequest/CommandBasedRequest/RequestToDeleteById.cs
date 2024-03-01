using System.Linq.Expressions;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to delete an entity by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to delete.</typeparam>
    /// <typeparam name="IdType">The type of the entity's identifier.</typeparam>
    public abstract class RequestToDeleteById<TEntity, IdType> :
        RequestToDelete<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestToDeleteById{TEntity, IdType}"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        public RequestToDeleteById(IdType id) 
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier of the entity to delete.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Returns an expression to identify the entity to delete based on its identifier.
        /// </summary>
        /// <returns>An expression representing the identification of the entity.</returns>
        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }

        /// <summary>
        /// Sets the identifier of the entity to delete.
        /// </summary>
        /// <param name="value">The new identifier value.</param>
        /// <returns>The current instance of <see cref="RequestToDeleteById{TEntity, IdType}"/>.</returns>
        public virtual RequestToDeleteById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
