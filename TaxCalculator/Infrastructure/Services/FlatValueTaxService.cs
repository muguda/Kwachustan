using TaxCalculator.Infrastructure.Interfaces;

namespace TaxCalculator.Infrastructure.Services
{
    /// <summary>
    /// The flat value:
    /// 10000 per year
    /// Else if the individual earns less than 200000 per year the tax will be at 5%
    /// </summary>
    public class FlatValueTaxService : ITaxCalculationService
    {

        const decimal MaxFlatValue = 200000m;
        const decimal FlatRate = 0.05m;
        const decimal FlatValueTax = 10000m;


        public decimal CalculateTax(decimal annualIncome)
        {
            if(annualIncome <=0)
            {
                return 0;
            }
            return annualIncome <= MaxFlatValue  ? annualIncome * FlatRate : FlatValueTax;

        }
    }
}
