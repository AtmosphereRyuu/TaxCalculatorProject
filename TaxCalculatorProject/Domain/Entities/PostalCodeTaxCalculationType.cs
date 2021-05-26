using Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PostalCodeTaxCalculationType
    {
        [Key]
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public TaxCalculationType TaxCalculationType { get; set; }
    }
}
