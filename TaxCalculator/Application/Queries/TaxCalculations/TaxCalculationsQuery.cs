using MediatR;
using TaxCalculator.Models.Dto;

namespace TaxCalculator.Application.Queries.TaxCalculations
{
    public class TaxCalculationsQuery: IRequest<TaxCalculationResponse>
    {
        public decimal AnnualIncome { get; set; }
        public string PostalCode { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
