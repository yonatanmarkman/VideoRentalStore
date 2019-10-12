using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Min18YearsIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			// ObjectInstance gives access to containing class - in this case, Customer.
			// To access it's properties, a cast is needed.
			var customer = (Customer)validationContext.ObjectInstance;

			// For first 2 options, birthdate validation isn't needed
			if (customer.MembershipTypeId == MembershipType.Unknown ||
				customer.MembershipTypeId == MembershipType.PayAsYouGo)
			{
				return ValidationResult.Success;
			}
			if (customer.Birthdate == null)
			{
				return new ValidationResult("Birthdate is required.");
			}

			// WIP: Make age calculation more accurate.
			var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

			return (age >= 18) 
				? ValidationResult.Success 
				: new ValidationResult("Customer should be at least 18 years old to go on a membership.");
		}
	}
}