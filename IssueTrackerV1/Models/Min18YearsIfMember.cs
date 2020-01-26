using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueTrackerV1.Models
{
    public class Min18YearsIfMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User) validationContext.ObjectInstance;

            if(user.MembershipTypeId == MembershipType.Unknown || 
               user.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if(user.Birthdate == null)
                return new ValidationResult("Birthdate is required. ");

            var age = DateTime.Today.Year - user.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Users should be at least 18 years old.");
        }
    }
}