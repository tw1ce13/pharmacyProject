﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Domain.Models;
public class Pharmacy
{
	public int Id { get; set; }
	public int WebId { get; set; }
	[ForeignKey("WebId")]
	public Web? Web { get; set; }
	public string? Address { get; set; }
	public string? Type { get; set; }
}

