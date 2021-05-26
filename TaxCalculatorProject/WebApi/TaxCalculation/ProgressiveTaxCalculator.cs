using System.Collections.Generic;
using WebApi.Interfaces.TaxCalculation;

namespace WebApi.TaxCalculation
{
    public class ProgressiveTaxCalculator : ITaxCalculator
    {
        public decimal Calculate(decimal annualIncome)
        {
            var progressiveTaxSettings = GetProgressiveTaxSettings();

            decimal totalTax = 0;
            decimal annualIncomeThatHasBeenTaxedSoFar = 0;
            decimal workingAnnualIncome = annualIncome;

            foreach (var progressiveTaxSetting in progressiveTaxSettings)
            {
                if (progressiveTaxSetting.To == 0)
                {
                    DetermineTaxOnRemainingAnnualIncome(progressiveTaxSetting.Rate);
                    break;
                }

                var workingUpperTaxValue = progressiveTaxSetting.To - annualIncomeThatHasBeenTaxedSoFar;

                if (workingAnnualIncome > workingUpperTaxValue)
                {
                    var partialDeterminedTax = workingUpperTaxValue * progressiveTaxSetting.Rate;
                    totalTax = totalTax + partialDeterminedTax;
                    annualIncomeThatHasBeenTaxedSoFar = annualIncomeThatHasBeenTaxedSoFar + workingUpperTaxValue;
                    workingAnnualIncome = workingAnnualIncome - workingUpperTaxValue;
                }
                else
                {
                    DetermineTaxOnRemainingAnnualIncome(progressiveTaxSetting.Rate);
                    break;
                }
            }

            return totalTax;

            void DetermineTaxOnRemainingAnnualIncome(decimal rate)
            {
                var partialDeterminedTax = workingAnnualIncome * rate;
                totalTax = totalTax + partialDeterminedTax;
            }
        }

        private static IEnumerable<ProgressiveTaxSetting> GetProgressiveTaxSettings()
        {
            var progressiveTaxSettings = new List<ProgressiveTaxSetting>()
            {
                new ProgressiveTaxSetting()
                {
                    Rate = 0.10m,
                    From = 0,
                    To = 8350
                },
                new ProgressiveTaxSetting()
                {
                    Rate = 0.15m,
                    From = 8351,
                    To = 33950
                },
                new ProgressiveTaxSetting()
                {
                    Rate = 0.25m,
                    From = 33951,
                    To = 82250
                },
                new ProgressiveTaxSetting()
                {
                    Rate = 0.28m,
                    From = 82251,
                    To = 171550
                },
                new ProgressiveTaxSetting()
                {
                    Rate = 0.33m,
                    From = 171551,
                    To = 372950
                },
                new ProgressiveTaxSetting()
                {
                    Rate = 0.35m,
                    From = 372951,
                    To = 0
                }
            };

            return progressiveTaxSettings;
        }
    }
}
