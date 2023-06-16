using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public int IdPharmacy { get; set; }
		[ForeignKey("IdPharmacy")]
		public Pharmacy? Pharmacy { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Post { get; set; }
	}
}

