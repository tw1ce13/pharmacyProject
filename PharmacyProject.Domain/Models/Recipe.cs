using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		public int IdPatient { get; set; }
		[ForeignKey("IdPatient")]
		public Patient? Patient { get; set; }
	}
}

