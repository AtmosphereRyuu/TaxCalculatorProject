using Microsoft.Extensions.Options;
using WebApi.AppSettingsModels;
using WebApi.Interfaces.TaxCalculation;

namespace WebApi.TaxCalculation
{
    public class FlatRateTaxCalculator : ITaxCalculator
    {
        private readonly IOptions<FlatRateTaxCalculatorOptions> _flatRateTaxCalculatorOptions;

        public FlatRateTaxCalculator(IOptions<FlatRateTaxCalculatorOptions> flatRateTaxCalculatorOptions)
        {
            _flatRateTaxCalculatorOptions = flatRateTaxCalculatorOptions;
        }

        public decimal Calculate(decimal annualIncome)
        {
            return annualIncome * _flatRateTaxCalculatorOptions.Value.DefaultTaxPercentage;
        }
    }
}

