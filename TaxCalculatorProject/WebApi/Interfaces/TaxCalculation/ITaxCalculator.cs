namespace WebApi.Interfaces.TaxCalculation
{
    public interface ITaxCalculator
    {
        decimal Calculate(decimal annualIncome);
    }
}
