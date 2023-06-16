using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL
{
	public class PharmacyContext : DbContext
	{

		public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            modelBuilder.Entity<Availability>().HasNoKey();
            modelBuilder.Entity<RecipeDrug>().HasNoKey();
        }

        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrdDrug> OrdersDrugs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDrug> RecipeDrugs { get; set; }
        public DbSet<Web> Webs { get; set; }
    }
}

