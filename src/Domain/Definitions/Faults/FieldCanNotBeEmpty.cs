using System.Globalization;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents an invariant fault that occurs when validating a field and its value is found to be empty.
    /// </summary>
    public class FieldCanNotBeEmpty : ValidationFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldCanNotBeEmpty"/> class
        /// with the specified field name and description.
        /// </summary>
        /// <param name="fieldName">The name of the field with an empty value.</param>
        /// <param name="description">A custom description for the fault (optional).</param>
        public FieldCanNotBeEmpty(string fieldName = "", string description = "") :
            base(outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "The value of the {0} field canot be empty.", fieldName))
        {
        }
    }
}