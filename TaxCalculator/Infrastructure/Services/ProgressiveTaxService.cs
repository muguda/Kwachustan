using TaxCalculator.Infrastructure.Interfaces;
namespace TaxCalculator.Infrastructure.Services
{
    /// <summary>
    ///
    /// https://corporatefinanceinstitute.com/resources/accounting/progressive-tax-system/
    /// https://en.wikipedia.org/wiki/Progressive_tax
    /// </summary>
    public class ProgressiveTaxService : ITaxCalculationService
    {

        /// <summary>
        /// The progressive tax system is a system that imposes a lower tax rate on low-income earners compared to those with a higher income, making it based on the taxpayer’s ability to pay.
        ///
        /// The progressive tax is calculated based on this table (be sure you understand how a progressive
        /// calculation works):
        ///Rate From To
        ///10% 0 8350
        ///15% 8351 33950 (0 to 8350 at 10%)
        ///25% 33951 82250 (8351 to 33950 - 15%)
        ///28% 82251 171550 (33951 - 82250 25%)
        ///33% 171551 372950 (82251 - 171550 28%)
        ///35% 372951 - (171551-372950 33%)
        /// </summary>
        /// <param name="annualIncome"></param>
        /// <returns></returns>
        public decimal CalculateTax(decimal annualIncome)
        {
            if (annualIncome <= 0)
            {
                return 0;
            }
            else
            if (annualIncome <= 8350)
            {
                return annualIncome * 0.10m;
            }
            else if (annualIncome <= 33950)
            {
                return CalculateTax(8350) + (annualIncome - 8350) * 0.15m;
            }
            else if (annualIncome <= 82250)
            {
                return CalculateTax(33950) + (annualIncome - 33950) * 0.25m;
            }
            else if (annualIncome <= 171550)
            {
                return CalculateTax(82250) + (annualIncome - 82250) * 0.28m;
            }
            else if (annualIncome <= 372950)
            {
                return CalculateTax(171550) + (annualIncome - 171550) * 0.33m;
            }
            else
            {
                return CalculateTax(372950) + (annualIncome - 372950) * 0.35m;
            }

        }


    }
}
