using System;
using Common.Enums;
using Microsoft.Extensions.Options;
using WebApi.AppSettingsModels;
using WebApi.Interfaces.TaxCalculation;

namespace WebApi.TaxCalculation
{
    public class TaxCalculatorFactory: ITaxCalculatorFactory
    {
        private readonly IOptions<FlatValueTaxCalculatorOptions> _flatValueTaxCalculatorOptions;
        private readonly IOptions<FlatRateTaxCalculatorOptions> _flatRateTaxCalculatorOptions;

        public TaxCalculatorFactory(IOptions<FlatValueTaxCalculatorOptions> flatValueTaxCalculatorOptions,
            IOptions<FlatRateTaxCalculatorOptions> flatRateTaxCalculatorOptions)
        {
            _flatValueTaxCalculatorOptions = flatValueTaxCalculatorOptions;
            _flatRateTaxCalculatorOptions = flatRateTaxCalculatorOptions;
        }

        public ITaxCalculator Get(TaxCalculationType taxCalculationType)
        {
            switch (taxCalculationType)
            {
                case TaxCalculationType.FlatRate:
                    return new FlatRateTaxCalculator(_flatRateTaxCalculatorOptions);
                case TaxCalculationType.FlatValue:
                    return new FlatValueTaxCalculator(_flatValueTaxCalculatorOptions);
                case TaxCalculationType.Progressive:
                    return new ProgressiveTaxCalculator();
                default:
                    throw new Exception($"Unexpected TaxCalculationType: {taxCalculationType}");
            }
        }
    }
}
