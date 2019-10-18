using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
	// This DTO is used for the Web API of the customer.
	public class CustomerDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter customer's name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		public byte MembershipTypeId { get; set; }

		// MembershipType property from Customer is mapped to this dto.
		// *This requires AutoMapper.
		public MembershipTypeDto MembershipType { get; set; }

		//[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}