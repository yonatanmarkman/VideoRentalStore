using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	// Model used for registering with an external service
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Driving License")]
		public string DrivingLicense { get; set; }

		[Required]
		[StringLength(50)]
		public string Phone { get; set; }
	}
}