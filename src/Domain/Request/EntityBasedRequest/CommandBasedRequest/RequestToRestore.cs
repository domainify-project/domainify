using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to restore a deleted entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to restore.</typeparam>
    public abstract class RequestToRestore<TEntity> :
        CommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Resolves the request to restore the specified entity.
        /// </summary>
        /// <param name="mediator">The mediator instance to handle the resolution.</param>
        /// <param name="entity">The entity to be restored.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Check if the entity is not deleted, if so, raise an invariant issue
            await new InvariantState<TEntity>()
                .DefineAnInvariant(
                result: !entity.IsDeleted,
                issue: new NoEntityWasDeletedSoRestoringItIsNotPossible(typeof(TEntity).Name))
                .AssestAsync(mediator);

            // Restore the entity
            entity.Restore();
        }
    }
}
