using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.membershipTypeId == MembershipType.unknown || customer.membershipTypeId == MembershipType.payAsYouGo)
                return ValidationResult.Success;

            if (customer.birthdate == null)
                return new ValidationResult("Birthdate Is Required");

            var age = DateTime.Today.Year - customer.birthdate.Value.Year;

            return age >= 18?
                ValidationResult.Success 
                : new ValidationResult("Customer Should Be Atleast 18 Years Old To Go In A Membership");
        }
    }
}