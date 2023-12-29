using AutoMapper;
using MediatR;
using TaxCalculator.Domain.Interfaces.Repositories;
using TaxCalculator.Models.Dto;
using TaxCalculator.Models.Entity;

namespace TaxCalculator.Application.Queries.PostalCode;

    /// <summary>
    /// TaxPostalCodeQueryHandler
    /// </summary>
    public class TaxPostalCodeQueryHandler : IRequestHandler<TaxPostalCodeQuery, List<TaxPostalCodeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITaxPostalCodeRepository _taxPostalCodeRepository;

        public TaxPostalCodeQueryHandler(IMapper mapper, ITaxPostalCodeRepository taxPostalCodeRepository)
        {
            _mapper = mapper;
            _taxPostalCodeRepository = taxPostalCodeRepository;
        }



        public async Task<List<TaxPostalCodeResponse>> Handle(TaxPostalCodeQuery request, CancellationToken cancellationToken)
        {
            var taxPostalCodes = await _taxPostalCodeRepository.GetAllAsync();
            var taxPostalCodeResponses = _mapper.Map<List<TaxPostalCodeResponse>>(taxPostalCodes);
            return taxPostalCodeResponses;

        }
    }



