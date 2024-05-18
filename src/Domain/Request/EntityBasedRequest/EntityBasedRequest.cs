using Newtonsoft.Json;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a base class for requests associated with a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    public abstract class EntityBasedRequest<TEntity> :
        BaseRequest
        where TEntity : BaseEntity<TEntity>
    {
 
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBasedRequest{TEntity}"/> class.
        /// </summary>
        public EntityBasedRequest() 
        {
            InvariantState = new();
        }

        /// <summary>
        /// Gets or sets the invariant state associated with the entity-based request.
        /// </summary>
        [JsonIgnore]
        public InvariantState<TEntity> InvariantState { get; private set; }
     }
}
