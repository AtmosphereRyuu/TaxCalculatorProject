using System;

namespace Common.WebApiModels.TaxCalculation
{
    public class TaxCalculationGetModel: TaxCalculationModelBase
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public decimal CalculatedTax { get; set; }
    }
}
