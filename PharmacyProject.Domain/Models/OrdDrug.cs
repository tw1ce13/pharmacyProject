using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models
{
	public class OrdDrug
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		[ForeignKey("OrderId")]
		public Order? Order { get; set; }
		public int DrugId { get; set; }
		[ForeignKey("DrugId")]
		public Drug? Drug { get; set; }
		public int DiscountId { get; set; }
		[ForeignKey("DiscountId")]
		public Discount? Discount { get; set; }
		public int Count { get; set; }
		public int Price { get; set; }

	}
}

