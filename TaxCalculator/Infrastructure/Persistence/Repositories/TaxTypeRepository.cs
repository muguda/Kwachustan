using TaxCalculator.Data;
using TaxCalculator.Domain.Interfaces.Repositories;
using TaxCalculator.Models.Entity;

namespace TaxCalculator.Infrastructure.Persistence.Repositories
{
    public class TaxTypeRepository: GenericRepository<TaxType, int>, ITaxTypeRepository
    {

        public TaxTypeRepository(TaxCalculatorDBContext context) : base(context)
        {
        }
    }
}
