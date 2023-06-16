using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models
{
	public class Drug
	{
		public int Id { get; set; }
		public int ClassId { get; set; }
		[ForeignKey("ClassId")]
		public Class? Class { get; set; }
		public string? Name { get; set; }
		public int Cost { get; set; }
		public bool IsRecipe { get; set; }
	}
}

