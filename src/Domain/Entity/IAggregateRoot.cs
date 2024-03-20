namespace Domainify.Domain
{
    public interface IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the version of the aggregate root.
        /// </summary>
        public double Version { get; set; }
    }
}
