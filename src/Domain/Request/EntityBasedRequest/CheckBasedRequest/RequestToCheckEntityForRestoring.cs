using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to check an entity before restoring it.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity to be restored.</typeparam>
    public abstract class RequestToCheckEntityForRestoring<TEntity> :
        CommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Resolves the request asynchronously by checking the entity before restoration.
        /// </summary>
        /// <param name="mediator">Mediator instance to handle communication between components.</param>
        /// <param name="entity">Entity to be checked.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Check if the entity is not deleted, if so, raise an invariant fault
            await new InvariantState<TEntity>()
                .DefineAnInvariant(
                condition: !entity.IsDeleted,
                fault: new NoEntityWasDeletedSoRestoringItIsNotPossibleFault(typeof(TEntity).Name))
                .AssestAsync(mediator);
        }
    }
}
