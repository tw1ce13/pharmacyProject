using System;
namespace PharmacyProject.Domain.Models
{
	public class DrugInOrder
	{
		public string? Name { get; set; }
		public int Count { get; set; }
		public int Price { get; set; }
		public DateTime Date { get; set; }

	}
}

