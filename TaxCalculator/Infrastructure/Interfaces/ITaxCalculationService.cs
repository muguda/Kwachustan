namespace TaxCalculator.Infrastructure.Interfaces
{
    public interface ITaxCalculationService
    {
        decimal CalculateTax(decimal annualIncome);
    }
}
