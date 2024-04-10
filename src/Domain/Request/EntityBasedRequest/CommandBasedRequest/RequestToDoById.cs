using System.Linq.Expressions;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to do a desired action on an entity by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity on which action is to be performed.</typeparam>
    /// <typeparam name="IdType">Type of the entity's identifier.</typeparam>
    public abstract class RequestToDoById<TEntity, IdType> :
        CommandRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestToDoById{TEntity, IdType}"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        public RequestToDoById(IdType id) 
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier of the entity.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Constructs an expression representing the identification of the entity based on its identifier.
        /// </summary>
        /// <returns>An expression representing the identification of the entity.</returns>
        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }

        /// <summary>
        /// Sets the identifier of the entity.
        /// </summary>
        /// <param name="value">The value to set as the identifier.</param>
        /// <returns>The current instance of <see cref="RequestToDoById{TEntity, IdType}"/>.</returns>
        public virtual RequestToDoById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
