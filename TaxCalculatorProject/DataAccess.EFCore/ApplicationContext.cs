using System;
using Common.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore
{
    public interface ITaxCalculatorContext
    {
        DbSet<PostalCodeTaxCalculationType> PostalCodeTaxCalculationTypes { get; set; }
        DbSet<TaxCalculation> TaxCalculations { get; set; }
        int SaveChanges();
    }

    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<PostalCodeTaxCalculationType> PostalCodeTaxCalculationTypes { get; set; }
        public DbSet<TaxCalculation> TaxCalculations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region seed data
            var postalCodeTaxCalculationTypes = new PostalCodeTaxCalculationType[] {
                new PostalCodeTaxCalculationType { Id = Guid.NewGuid(), PostalCode = "7441", TaxCalculationType = TaxCalculationType.Progressive},
                new PostalCodeTaxCalculationType { Id = Guid.NewGuid(), PostalCode = "A100", TaxCalculationType = TaxCalculationType.FlatValue},
                new PostalCodeTaxCalculationType { Id = Guid.NewGuid(), PostalCode = "7000", TaxCalculationType = TaxCalculationType.FlatRate},
                new PostalCodeTaxCalculationType { Id = Guid.NewGuid(), PostalCode = "1000", TaxCalculationType = TaxCalculationType.Progressive},
            };

            modelBuilder.Entity<PostalCodeTaxCalculationType>().HasData(postalCodeTaxCalculationTypes);

            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
