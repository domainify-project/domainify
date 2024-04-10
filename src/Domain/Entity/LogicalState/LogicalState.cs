 
using System.Reflection;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a state for managing logical preventers and faults in the domain model.
    /// </summary>
    public class LogicalState
    {
        /// <summary>
        /// The list of faults associated with the logical state.
        /// </summary>
        private readonly List<IFault> _faults = new();

        /// <summary>
        /// The list of logical preventers to be assessed.
        /// </summary>
        private readonly List<LogicalPreventer> _preventers = new();

        /// <summary>
        /// Gets the list of faults associated with the logical state.
        /// </summary>
        public List<IFault> GetFaults() => _faults;

        /// <summary>
        /// Gets the list of logical preventers.
        /// </summary>
        public List<LogicalPreventer> GetPreventers() => _preventers;

        /// <summary>
        /// Adds a logical preventer to be assessed.
        /// </summary>
        /// <param name="preventer">The logical preventer to add.</param>
        /// <returns>The current instance of the logical state for fluent chaining.</returns>
        public LogicalState AddAnPreventer(LogicalPreventer preventer)
        {
            _preventers.Add(preventer);

            return this;
        }

        /// <summary>
        /// Describes a logical preventer based on a specified condition and associated fault.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="fault">The fault associated with the preventer.</param>
        /// <returns>The current instance of the logical state for fluent chaining.</returns>
        public LogicalState DescribeAPreventer(
            bool condition,
            IFault fault)
        {
            if (condition)
                _faults.Add(fault);

            return this;
        }

        /// <summary>
        /// Describes a logical preventer based on a specified condition and associated fault.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="fault">The fault associated with the preventer.</param>
        /// <returns>The current instance of the logical state for fluent chaining.</returns>
        public LogicalState DescribeAPreventer(
            Func<bool> condition,
            IFault fault)
        {
            if (condition())
                _faults.Add(fault);

            return this;
        }

        /// <summary>
        /// Adds an fault directly to the logical state.
        /// </summary>
        /// <param name="fault">The fault to add.</param>
        /// <returns>The current instance of the logical state for fluent chaining.</returns>
        public LogicalState AddFault(IFault fault)
        {
            _faults.Add(fault);
   
            return this;
        }

        /// <summary>
        /// Asynchronously assesses all registered logical preventers and raises a logical error exception if any faults are detected.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AssesstAsync()
        {
            foreach (var preventer in _preventers)
            {
                if (await preventer.ResolveAsync() && preventer.GetFault() != null)
                    _faults.Add(preventer.GetFault()!);
            }

            if (_faults.Count > 0)
                ThrowLogicalErrorException();
        }

        /// <summary>
        /// Throws a logical error exception containing the list of detected faults.
        /// </summary>
        private void ThrowLogicalErrorException()
        {
            throw new ErrorException(
                new Error(
                    service: Assembly.GetEntryAssembly()!.GetName().Name!,
                    errorType: ErrorType.Logical,
                    faults: _faults));
        }
    }
}
