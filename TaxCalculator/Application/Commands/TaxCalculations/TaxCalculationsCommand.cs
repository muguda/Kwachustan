using MediatR;
using TaxCalculator.Models.Dto;

namespace TaxCalculator.Application.Commands.TaxCalculations
{
    public class TaxCalculationsCommand: IRequest<TaxCalculationResponse>
    {
        public decimal AnnualIncome { get; set; }
        public string PostalCode { get; set; }
    }
}
