using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to delete an entity permanently.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity to be deleted.</typeparam>
    public abstract class RequestToDeletePermanently<TEntity> :
        RequestToCheckEntityForDeletingPermanently<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Resolves the request asynchronously by deleting the entity permanently.
        /// </summary>
        /// <param name="mediator">Mediator instance to handle the resolution.</param>
        /// <param name="entity">Entity to be deleted permanently.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Perform permanent deletion of the entity
            entity.DeletePermanently();
        }

        public override void Prepare(TEntity entity)
        {
            base.Prepare(entity);
        }
    }
}
