using MediatR;
using TaxCalculator.Models.Dto;

namespace TaxCalculator.Application.Queries.PostalCode
{
    public class TaxPostalCodeQuery: IRequest<List<TaxPostalCodeResponse>>
    {

    }
}
