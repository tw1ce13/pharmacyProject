using System;
namespace PharmacyProject.Domain.Models
{
    public class DrugResult
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsRecipe { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
        public string? Type { get; set; }
        public DateTime ExpirationData { get; set; }
    }
}


