using System.Runtime.Serialization;

namespace Domainify
{
    /// <summary>
    /// Represents an interface for defining faults.
    /// </summary>
    public interface IFault
    {
        /// <summary>
        /// Gets or sets the name of the fault.
        /// </summary>
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the fault.
        /// </summary>
        [DataMember(Order = 2)]
        public string Description { get; set; }
    }
}
