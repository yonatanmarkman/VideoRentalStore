using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Customer
	{
		public int Id { get; set; }

		// Data annotations are used both for server-side, and client-side validation.
		// On the server-side - when a Customer object is passed to an ActionResult function.
		// On the client-side - When rendering input fields using HTML Helper methods,
		// RazorViewEngine adds additional attributes to the HTML markup, based on the data annotations.
		// On the client side, jQuery checks the data attributes for each field, to check the annotations.
		// if the field is not valid, it will render the validation message next to it.
		// *Note: client-side validation only works with STANDARD data annotations. It doesn't work with custom annotations.
		[Required(ErrorMessage = "Please enter customer's name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		public MembershipType MembershipType { get; set; }

		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; } // Navigation Property
		// byte is implicitly required, so it can't have a null value

		[Display(Name = "Date of Birth")]
		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}