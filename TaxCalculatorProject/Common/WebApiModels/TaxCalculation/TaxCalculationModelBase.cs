namespace Common.WebApiModels.TaxCalculation
{
    public abstract class TaxCalculationModelBase
    {
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
    }
}
