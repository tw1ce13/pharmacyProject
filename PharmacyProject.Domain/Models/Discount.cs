using System;
using PharmacyProject.Domain.Enum;

namespace PharmacyProject.Domain.Models
{
	public class Discount
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Type { get; set; }
		public int? Value { get; set; }
	}
}

