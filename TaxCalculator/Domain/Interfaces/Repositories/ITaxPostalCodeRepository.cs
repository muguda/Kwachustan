using TaxCalculator.Models.Entity;

namespace TaxCalculator.Domain.Interfaces.Repositories
{
    public interface ITaxPostalCodeRepository: IGenericRepository<TaxPostalCode, int>
    {
        Task<TaxPostalCode> GetByPostalCodeAsync(string postalCode);
    }
}
