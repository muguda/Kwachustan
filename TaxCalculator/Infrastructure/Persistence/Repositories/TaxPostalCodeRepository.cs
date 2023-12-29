using Microsoft.EntityFrameworkCore;
using TaxCalculator.Data;
using TaxCalculator.Domain.Interfaces.Repositories;
using TaxCalculator.Models.Entity;

namespace TaxCalculator.Infrastructure.Persistence.Repositories
{
    public class TaxPostalCodeRepository: GenericRepository<TaxPostalCode, int>, ITaxPostalCodeRepository
    {

        public TaxPostalCodeRepository(TaxCalculatorDBContext context) : base(context)
        {
        }

        /// <summary>
        ///  get by postal code
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        public async Task<TaxPostalCode> GetByPostalCodeAsync(string postalCode)
        {
           return await _dbContext.TaxPostalCodes.FirstOrDefaultAsync(x => x.PostalCode == postalCode);
        }
    }
}
