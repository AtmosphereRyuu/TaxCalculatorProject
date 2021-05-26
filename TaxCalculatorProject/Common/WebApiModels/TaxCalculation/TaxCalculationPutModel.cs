using System;

namespace Common.WebApiModels.TaxCalculation
{
    public class TaxCalculationPutModel: TaxCalculationModelBase
    {
        public Guid Id { get; set; }
        public decimal CalculatedTax { get; set; }
    }
}
