using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to retrieve a specific item of a certain type and return a result.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    /// <typeparam name="TReturnedType">The type of the result returned by the request.</typeparam>
    public abstract class QueryItemRequest<TEntity, TReturnedType>
        : QueryRequest<TEntity>, IRequest<TReturnedType>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Asynchronously resolves the request using the provided mediator.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the request.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task ResolveAsync(IMediator mediator)
        {
        }

        /// <summary>
        /// Asynchronously handles the resolution of the query request using the provided mediator and the associated entity.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the query request.</param>
        /// <param name="entity">The associated entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task ResolveAsync(IMediator mediator, TEntity entity)
        {
        }

        /// <summary>
        /// Prepares the specified entity for further processing or operation such as some come pre-defined invariants.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity being prepared.</typeparam>
        /// <param name="entity">The entity to be prepared.</param>
        public virtual void Prepare(TEntity entity)
        {
            InvariantState.DefineAnInvariant(
                condition: entity == null && PreventIfNoEntityWasFound,
                fault: new NoEntityWasFoundFault(typeof(TEntity).Name));
        }
    }
}
