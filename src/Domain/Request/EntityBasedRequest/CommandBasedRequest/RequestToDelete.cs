using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to delete an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to delete.</typeparam>
    public abstract class RequestToDelete<TEntity> :
        CommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Resolves the request to delete the specified entity.
        /// </summary>
        /// <param name="mediator">The mediator instance to handle the resolution.</param>
        /// <param name="entity">The entity to be deleted.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Check if the entity is already deleted, if so, raise an invariant fault
            await new InvariantState<TEntity>()
                .DefineAnInvariant(
                result: entity.IsDeleted,
                fault: new TheEntityWasDeletedSoDeletingItAgainIsNotPossible(typeof(TEntity).Name))
                .AssestAsync(mediator);

            // Mark the entity as deleted
            entity.Delete();
        }
    }
}
