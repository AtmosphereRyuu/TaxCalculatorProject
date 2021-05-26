using Common.Enums;

namespace WebApi.Interfaces.TaxCalculation
{
    public interface ITaxCalculatorFactory
    {
        ITaxCalculator Get(TaxCalculationType taxCalculationType);
    }
}
