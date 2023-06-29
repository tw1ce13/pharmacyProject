using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models;
public class Availability
{
    public int Id { get; set; }
    public int PharmacyId { get; set; }
    [ForeignKey("PharmacyId")]
    public Pharmacy? Pharmacy { get; set; }
    public int DrugId { get; set; }
    [ForeignKey("DrugId")]
    public Drug? Drug { get; set; }
    public int DeliveryId { get; set; }
    [ForeignKey("DeliveryId")]
    public Delivery? Delivery { get; set; }
    public int Count { get; set; }
}

