using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TaxCalculation
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal CalculatedTax { get; set; }
    }
}
