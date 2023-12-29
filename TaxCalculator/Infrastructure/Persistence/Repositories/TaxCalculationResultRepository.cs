using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Objects;
using TaxCalculator.Data;
using TaxCalculator.Domain.Interfaces.Repositories;
using TaxCalculator.Models.Entity;

namespace TaxCalculator.Infrastructure.Persistence.Repositories
{
    public class TaxCalculationResultRepository : GenericRepository<TaxCalculationResult, int>, ITaxCalculationResultRepository
    {
        public TaxCalculationResultRepository(TaxCalculatorDBContext context) : base(context)
        {
        }

        public async Task<TaxCalculationResult> GetTaxCalculationResultByDateAndPostalCodeAsync(DateTime createdDate, decimal annualIncome, string postalCode)
        {
            return await _dbContext.TaxCalculationResults
                .FirstOrDefaultAsync(x => x.DateCreated.Year == createdDate.Year
                && x.DateCreated.Month == createdDate.Month
                && x.DateCreated.Day == createdDate.Day
                && x.DateCreated.Hour == createdDate.Hour
                && x.DateCreated.Minute == createdDate.Minute
                && x.DateCreated.Second == createdDate.Second
                && x.AnnualIncome == annualIncome && x.PostalCode == postalCode);
        }
    }
}
