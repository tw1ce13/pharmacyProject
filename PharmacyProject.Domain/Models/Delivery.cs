using System;
namespace PharmacyProject.Domain.Models
{
	public class Delivery
	{
		public int Id { get; set; }
		public DateTime CreateData { get; set; }
		public DateTime ExpirationData { get; set; }
	}
}

