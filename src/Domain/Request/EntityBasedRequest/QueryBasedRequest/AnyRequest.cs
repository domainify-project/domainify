using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a base class for any request with specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class AnyRequest<TEntity>
        : QueryRequest<TEntity>, IRequest<bool>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Resolves the request asynchronously.
        /// </summary>
        /// <param name="mediator">The mediator to use for resolving.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task ResolveAsync(IMediator mediator)
        {
        }
    }
}
