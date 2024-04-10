using MediatR;
using System.Linq.Expressions;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a base class for command requests associated with a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the command request.</typeparam>
    public abstract class BaseCommandRequest<TEntity> :
        EntityBasedRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Gets the expression used for identifying the entity associated with the command.
        /// </summary>
        /// <returns>The identification expression for the entity, or null if not applicable.</returns>
        public virtual Expression<Func<TEntity, bool>>? Identification()
        {
            return null;
        }

        /// <summary>
        /// Prepares the specified entity for further processing or operation such as some come pre-defined invariants.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity being prepared.</typeparam>
        /// <param name="entity">The entity to be prepared.</param>
        public virtual void Prepare(TEntity entity)
        {
        }

        /// <summary>
        /// Asynchronously resolves the command request.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the command request.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task ResolveAsync(IMediator mediator)
        {
        }

        /// <summary>
        /// Asynchronously resolves the command request, retrieves the associated entity, and returns it.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the command request.</param>
        /// <returns>A task representing the asynchronous operation and returning the associated entity.</returns>
        public async virtual Task<TEntity> ResolveAndGetEntityAsync(IMediator mediator)
        {
            return null;
        }

        /// <summary>
        /// Asynchronously handles the resolution of the command request using the provided mediator and the associated entity.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the command request.</param>
        /// <param name="entity">The associated entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task ResolveAsync(IMediator mediator, TEntity entity)
        {
        }
    }
}
