

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a validation rule that prevents an action if the start date is later than the end date for a specified entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity being validated.</typeparam>
    public class PreventIfStartDateIsLaterThanEndDate<TEntity> :
        Validation
        where TEntity : BaseEntity<TEntity>
    {
        private DateTime _startDate;
        private DateTime _endDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreventIfStartDateIsLaterThanEndDate{TEntity}"/> class
        /// with the specified start and end dates.
        /// </summary>
        /// <param name="startDate">The start date for validation.</param>
        /// <param name="endDate">The end date for validation.</param>
        public PreventIfStartDateIsLaterThanEndDate(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        /// <summary>
        /// Resolves the validation rule by checking if the start date is later than the end date.
        /// </summary>
        /// <returns>True if the start date is later than the end date, indicating validation failure; otherwise, false.</returns>
        public override bool Resolve()
        {
            if(_startDate > _endDate) 
                return true;

            return false;
        }

        /// <summary>
        /// Gets the validation fault if the start date is later than the end date.
        /// </summary>
        /// <returns>An instance of <see cref="IFault"/> representing the validation fault.</returns>
        public override IFault? GetFault()
        {
            if (Resolve())
                return new StartDateCanNotBeLaterThanEndDateFault(typeof(TEntity).Name, Description);

            return null;
        }
    }
}
