using AutoMapper;
using MediatR;
using TaxCalculator.Domain.Interfaces.Repositories;
using TaxCalculator.Models.Dto;

namespace TaxCalculator.Application.Queries.TaxCalculations
{
    public class TaxCalculationsQueryHandler : IRequestHandler<TaxCalculationsQuery, TaxCalculationResponse>
    {

        private readonly IMapper _mapper;
        private readonly ITaxCalculationResultRepository _taxCalculationResultRepository;

        public TaxCalculationsQueryHandler(IMapper mapper, ITaxCalculationResultRepository taxCalculationResultRepository)
        {
            _mapper = mapper;
            _taxCalculationResultRepository = taxCalculationResultRepository;
        }

        public async Task<TaxCalculationResponse> Handle(TaxCalculationsQuery request, CancellationToken cancellationToken)
        {
            var taxResult  =  await _taxCalculationResultRepository.GetTaxCalculationResultByDateAndPostalCodeAsync(request.DateCreated, request.AnnualIncome, request.PostalCode);
            return _mapper.Map<TaxCalculationResponse>(taxResult);


        }
    }
}
