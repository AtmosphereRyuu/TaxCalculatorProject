using Microsoft.Extensions.Options;
using WebApi.AppSettingsModels;
using WebApi.Interfaces.TaxCalculation;

namespace WebApi.TaxCalculation
{
    public class FlatValueTaxCalculator : ITaxCalculator
    {
        private readonly IOptions<FlatValueTaxCalculatorOptions> _flatValueTaxCalculatorOptions;

        public FlatValueTaxCalculator(IOptions<FlatValueTaxCalculatorOptions> flatValueTaxCalculatorOptions)
        {
            _flatValueTaxCalculatorOptions = flatValueTaxCalculatorOptions;
        }

        public decimal Calculate(decimal annualIncome)
        {
            if (annualIncome >= _flatValueTaxCalculatorOptions.Value.AnnualIncomeLowerLimit)
            {
                return _flatValueTaxCalculatorOptions.Value.DefaultRate;
            }

            return annualIncome * _flatValueTaxCalculatorOptions.Value.LowerLimitTaxPercentage;
        }
    }
}
