using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models
{
	public class RecipeDrug
	{
		public int Id { get; set; }
		public int DrugId { get; set; }
		[ForeignKey("DrugId")]
		public Drug? Drug { get; set; }
		public int RecipeId { get; set; }
		[ForeignKey("RecipeId")]
		public Recipe? Recipe { get; set; }
		public int Count { get; set; }
	}
}

