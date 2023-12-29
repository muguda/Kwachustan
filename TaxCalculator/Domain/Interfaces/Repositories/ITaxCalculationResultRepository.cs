using TaxCalculator.Models.Entity;

namespace TaxCalculator.Domain.Interfaces.Repositories
{
    public interface ITaxCalculationResultRepository: IGenericRepository<TaxCalculationResult, int>
    {
        Task<TaxCalculationResult> GetTaxCalculationResultByDateAndPostalCodeAsync(DateTime createdDate, decimal AnnualAmount, string postalCode);
    }
}
