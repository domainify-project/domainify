using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to permanently delete an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to permanently delete.</typeparam>
    public abstract class RequestToDeletePermanently<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Resolves the request to permanently delete the specified entity.
        /// </summary>
        /// <param name="mediator">The mediator instance to handle the resolution.</param>
        /// <param name="entity">The entity to be permanently deleted.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Permanently delete the entity
            entity.DeletePermanently();
        }
    }
}
