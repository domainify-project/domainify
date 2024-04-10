﻿

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Domainify.Domain
{
    /// <summary>
    /// Represents a base attribute for field validations.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public abstract class FieldValidationAttribute : Attribute
    {
        private string _description;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValidationAttribute"/> class.
        /// </summary>
        public FieldValidationAttribute()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValidationAttribute"/> class with an optional description.
        /// </summary>
        /// <param name="description">The description of the field validation.</param>
        protected FieldValidationAttribute(string description)
        {
            _description = description;
        }



        /// <summary>
        /// Gets the description of the field validation.
        /// </summary>
        public string? Description
        {
            get => _description;
        }

        /// <summary>
        /// Determines whether the provided value is valid according to the validation rule.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>True if the value is valid, false otherwise.</returns>
        public virtual bool IsValid(object? value)
        {
            return true;
        }

        /// <summary>
        /// Validates a field based on the provided value and adds any resulting faults to the collection.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="_issues">The collection to add faults to, if any.</param>
        /// <param name="propertyName">The name of the property being validated.</param>
        public virtual void Validate(
            object? value,
            ICollection<IFault> _issues,
            string propertyName = "")
        {
        }
    }
}
