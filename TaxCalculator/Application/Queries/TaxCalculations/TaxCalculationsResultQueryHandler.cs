using AutoMapper;
using MediatR;
using TaxCalculator.Domain.Interfaces.Repositories;
using TaxCalculator.Models.Dto;

namespace TaxCalculator.Application.Queries.TaxCalculations
{
    public class TaxCalculationsResultQueryHandler: IRequestHandler<TaxCalculationsResultQuery, List<TaxCalculationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITaxCalculationResultRepository _taxCalculationRepository;

        public TaxCalculationsResultQueryHandler(IMapper mapper, ITaxCalculationResultRepository taxCalculationRepository)
        {
            _mapper = mapper;
            _taxCalculationRepository = taxCalculationRepository;
        }

        public async Task<List<TaxCalculationResponse>> Handle(TaxCalculationsResultQuery request, CancellationToken cancellationToken)
        {
            var taxCalculationResults = await _taxCalculationRepository.GetAllAsync();
            return _mapper.Map<List<TaxCalculationResponse>>(taxCalculationResults);
        }
    }
}
