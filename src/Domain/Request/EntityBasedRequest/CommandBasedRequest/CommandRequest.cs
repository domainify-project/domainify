using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a command request for performing operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity this command request operates on.</typeparam>
    public abstract class CommandRequest<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
    }
}
