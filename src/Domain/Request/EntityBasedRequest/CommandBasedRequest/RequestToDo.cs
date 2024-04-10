using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to do a desired action on an entity.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity on which action is to be performed.</typeparam>
    public abstract class RequestToDo<TEntity> :
        CommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Resolves the request asynchronously by executing the desired action on the entity.
        /// </summary>
        /// <param name="mediator">Mediator instance to handle communication between components.</param>
        /// <param name="entity">Entity on which action is to be performed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
        }
    }
}
