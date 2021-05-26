namespace WebApi.AppSettingsModels
{
    public class FlatValueTaxCalculatorOptions
    {
        public decimal DefaultRate { get; set; }
        public decimal AnnualIncomeLowerLimit { get; set; }
        public decimal LowerLimitTaxPercentage { get; set; }
    }
}
