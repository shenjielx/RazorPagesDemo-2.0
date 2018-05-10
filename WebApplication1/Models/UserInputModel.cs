using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class UserInputModel
	{
		[Required]
		[StringLength(450, MinimumLength = 3)]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public ClaimsItem Claim { get; set; }

		public List<ClaimsItem> Claims { get; set; } //= new List<ClaimsItem> { };

		public class ClaimsItem
		{
			public string Type { get; set; }
			public string Value { get; set; }
		}
	}
}
