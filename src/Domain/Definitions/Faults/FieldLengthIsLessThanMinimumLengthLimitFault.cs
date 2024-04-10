using System.Globalization;

namespace Domainify.Domain
{
    // <summary>
    /// Represents an invariant fault that occurs when validating a field, and its length is less than the specified minimum length limit.
    /// </summary>
    public class FieldLengthIsLessThanMinimumLengthLimitFault : ValidationFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldLengthIsLessThanMinimumLengthLimitFault"/> class
        /// with the specified minimum length, field name, and description.
        /// </summary>
        /// <param name="minLength">The minimum allowed length for the field.</param>
        /// <param name="fieldName">The name of the field with a length less than the minimum length limit.</param>
        /// <param name="description">A custom description for the invariant fault (optional).</param>
        public FieldLengthIsLessThanMinimumLengthLimitFault(
            int minLength, string fieldName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "The {0} field minimum length is less than the minimum length pageSize. The field's length should be more than {1} characters.",
                fieldName, minLength))
        {
        }
    }
}
