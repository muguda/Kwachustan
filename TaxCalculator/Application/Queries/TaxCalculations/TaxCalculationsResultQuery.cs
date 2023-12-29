using MediatR;
using TaxCalculator.Models.Dto;

namespace TaxCalculator.Application.Queries.TaxCalculations
{
    public class TaxCalculationsResultQuery: IRequest<List<TaxCalculationResponse>>
    {
    }
}
