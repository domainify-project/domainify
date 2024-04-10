﻿

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a request to check an invariant condition for a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    public abstract class InvariantRequest<TEntity>
        : AnyRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Gets or sets the description associated with the invariant request.
        /// </summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the fault related to the invariant condition. Returns null if no fault exists.
        /// </summary>
        /// <returns>The fault related to the invariant condition, or null if no fault exists.</returns>
        public virtual IFault? GetFault()
        {
            return null;
        }

        /// <summary>
        /// Sets the description associated with the invariant request.
        /// </summary>
        /// <param name="value">The description to be set.</param>
        /// <returns>The current instance of the invariant request for fluent chaining.</returns>
        public InvariantRequest<TEntity> WithDescription(string value)
        {
            Description = value;
            return this;
        }
    }
}
