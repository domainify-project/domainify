using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to delete an entity permanently.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity to be deleted.</typeparam>
    public abstract class RequestToDeletePermanently<TEntity> :
        CommandRequest<TEntity>
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
            // Check if the entity is already deleted before attempting permanent deletion
            await new InvariantState<TEntity>()
                .DefineAnInvariant(
                result: !entity.IsDeleted,
                issue: new TheEntityIsNotAlreadyDeletedSoDeletingItPermanentlyIsNotPossible(typeof(TEntity).Name))
                .AssestAsync(mediator);

            // Perform permanent deletion of the entity
            entity.DeletePermanently();
        }
    }
}
