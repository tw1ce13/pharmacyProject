using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models;
public class Recipe
{
	public int Id { get; set; }
	public int PatientId { get; set; }
	[ForeignKey("PatientId")]
	public Patient? Patient { get; set; }
}

