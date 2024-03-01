using System.Linq.Expressions;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to restore a deleted entity by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to restore.</typeparam>
    /// <typeparam name="IdType">The type of the entity's identifier.</typeparam>
    public abstract class RequestToRestoreById<TEntity, IdType> :
        RequestToRestore<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestToRestoreById{TEntity, IdType}"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity to restore.</param>
        public RequestToRestoreById(IdType id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier of the entity to restore.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Returns an expression to identify the entity to restore based on its identifier.
        /// </summary>
        /// <returns>An expression representing the identification of the entity.</returns>
        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }

        /// <summary>
        /// Sets the identifier of the entity to restore.
        /// </summary>
        /// <param name="value">The new identifier value.</param>
        /// <returns>The current instance of <see cref="RequestToRestoreById{TEntity, IdType}"/>.</returns>
        public virtual RequestToRestoreById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
