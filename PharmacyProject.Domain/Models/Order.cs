using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models
{
	public class Order
	{
		public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PharmacyId { get; set; }
		[ForeignKey("PharmacyId")]
		public Pharmacy? Pharmacy { get; set; }
		public int EmployeeId { get; set; }
		[ForeignKey("EmployeeId")]
		public Employee? Employee { get; set; }
		public int PatientId { get; set; }
		[ForeignKey("PatientId")]
		public Patient? Patient { get; set; }
		public int DiscountId { get; set; }
		[ForeignKey("DiscountId")]
		public Discount? Discount { get; set; }
		
	}
}

