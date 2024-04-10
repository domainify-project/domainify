using System.Linq.Expressions;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to check an entity before deleting it by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity to be checked and potentially deleted.</typeparam>
    /// <typeparam name="IdType">Type of the entity's identifier.</typeparam>
    public abstract class RequestToCheckEntityForDeletingById<TEntity, IdType> :
        RequestToCheckEntityForDeleting<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestToCheckEntityForDeletingById{TEntity, IdType}"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to be checked.</param>
        public RequestToCheckEntityForDeletingById(IdType id) 
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier of the entity to be checked.
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
        /// Sets the identifier of the entity to be checked.
        /// </summary>
        /// <param name="value">The value to set as the identifier.</param>
        /// <returns>The current instance of <see cref="RequestToCheckEntityForDeletingById{TEntity, IdType}"/>.</returns>
        public virtual RequestToCheckEntityForDeletingById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
