using TaxCalculator.Infrastructure.Interfaces;

namespace TaxCalculator.Infrastructure.Services
{
    /// <summary>
    /// The flat rate:
    /// All users pay 17.5% tax on their income
    /// </summary>
    public class FlatRateTaxService : ITaxCalculationService
    {
        const decimal FlatRate = 0.175m;
        public decimal CalculateTax(decimal annualIncome)
        {
            return annualIncome <= 0 ? 0: annualIncome * FlatRate;
        }
    }
}
