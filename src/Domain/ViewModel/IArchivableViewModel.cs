namespace Domainify.Domain
{
    /// <summary>
    /// Represents a view model that supports deleting functionality.
    /// </summary>
    public interface IDeletableViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the item is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
