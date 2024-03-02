using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a command request that returns a specific type of result after execution.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity this command request operates on.</typeparam>
    /// <typeparam name="IReturnedType">The type of result returned by this command request.</typeparam>
    public abstract class ReturnableCommandRequest<TEntity, IReturnedType> :
        BaseCommandRequest<TEntity>, IRequest<IReturnedType>
        where TEntity : BaseEntity<TEntity>
    {
    }
}
