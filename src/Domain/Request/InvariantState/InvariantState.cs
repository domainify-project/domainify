
using System.Reflection;
using MediatR;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a state for managing invariant requests and faults for a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the invariant state.</typeparam>
    public class InvariantState<TEntity> where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// The list of faults associated with the invariant state.
        /// </summary>
        private readonly List<IFault> _faults = new();

        /// <summary>
        /// The list of invariant requests to be assessed.
        /// </summary>
        private readonly List<InvariantRequest<TEntity>> _invariantRequests = new();

        /// <summary>
        /// Gets the list of faults associated with the invariant state.
        /// </summary>
        public List<IFault> GetFaults() => _faults;

        /// <summary>
        /// Gets the list of invariant requests.
        /// </summary>
        public List<InvariantRequest<TEntity>> GetPreventers() => _invariantRequests;

        /// <summary>
        /// Adds an invariant request to be assessed.
        /// </summary>
        /// <param name="request">The invariant request to add.</param>
        /// <returns>The current instance of the invariant state for fluent chaining.</returns>
        public InvariantState<TEntity> AddAnInvariantRequest(InvariantRequest<TEntity> request)
        {
            _invariantRequests.Add(request);

            return this;
        }

        /// <summary>
        /// Defines an invariant based on a specified condition and associated fault.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="fault">The fault associated with the invariant.</param>
        /// <returns>The current instance of the invariant state for fluent chaining.</returns>
        public InvariantState<TEntity> DefineAnInvariant(
            bool condition, IFault fault)
        {
            if (condition)
                _faults.Add(fault);

            return this;
        }

        /// <summary>
        /// Defines an invariant based on a specified fault and condition.
        /// </summary>
        /// <param name="fault">The fault associated with the invariant.</param>
        /// <param name="condition">The condition to evaluate.</param>
        /// <returns>The current instance of the invariant state for fluent chaining.</returns>
        public InvariantState<TEntity> DefineAnInvariant(
            IFault fault, Func<bool> condition)
        {
            if (condition())
                _faults.Add(fault);

            return this;
        }

        /// <summary>
        /// Asynchronously assesses all registered invariant requests and raises an error exception if any faults are detected.
        /// </summary>
        /// <param name="mediator">The mediator used to send invariant requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AssestAsync(IMediator mediator)
        {
            foreach (var request in _invariantRequests)
            {
                if ((bool)(await mediator.Send(request))!)
                    if (request.GetFault() != null)
                        _faults.Add(request.GetFault()!);
            }

            if (_faults.Count > 0)
                ThrowErrorException();
        }

        /// <summary>
        /// Throws an error exception containing the list of detected invariant faults.
        /// </summary>
        private void ThrowErrorException()
        {
            throw new ErrorException(
                new Error(
                    service: Assembly.GetEntryAssembly()!.GetName().Name!,
                    errorType: ErrorType.Invariant,
                    faults: _faults));
        }
    }
}
