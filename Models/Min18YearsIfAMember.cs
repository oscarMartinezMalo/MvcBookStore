using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBookStore.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGO)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthday is required");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ?
                ValidationResult.Success :
                new ValidationResult("Customer should be at least 18 years old to go to a membership.");
        }
    }
}