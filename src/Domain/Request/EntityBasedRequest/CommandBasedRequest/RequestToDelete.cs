using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to delete an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to delete.</typeparam>
    public abstract class RequestToDelete<TEntity> :
        RequestToCheckEntityForDeleting<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Resolves the request to delete the specified entity.
        /// </summary>
        /// <param name="mediator">The mediator instance to handle the resolution.</param>
        /// <param name="entity">The entity to be deleted.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Mark the entity as deleted
            entity.Delete();
        }

        public override void Prepare(TEntity entity)
        {
            base.Prepare(entity);
        }
    }
}
