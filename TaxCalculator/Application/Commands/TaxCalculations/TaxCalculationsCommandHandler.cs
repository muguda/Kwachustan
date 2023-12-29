using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR.Protocol;
using TaxCalculator.Application.Queries.TaxCalculations;
using TaxCalculator.Domain.Interfaces.Repositories;
using TaxCalculator.Infrastructure.Interfaces;
using TaxCalculator.Models.Dto;
using TaxCalculator.Models.Entity;

namespace TaxCalculator.Application.Commands.TaxCalculations
{
    public class TaxCalculationsCommandHandler : IRequestHandler<TaxCalculationsCommand, TaxCalculationResponse>
    {
        private readonly ITaxPostalCodeRepository _taxPostalCodeRepository;
        private ITaxCalculationService _taxCalculationService;
        private readonly ITaxServiceFactory _taxServiceFactory;
        private readonly ITaxCalculationResultRepository _taxCalculationResultRepository;
        private readonly IMapper _mapper;

        public TaxCalculationsCommandHandler(ITaxPostalCodeRepository taxPostalCodeRepository,
            ITaxCalculationResultRepository taxCalculationResultRepository,
            ITaxCalculationService taxCalculationService,
             IMapper mapper,
            ITaxServiceFactory taxServiceFactory)
        {
            _taxPostalCodeRepository = taxPostalCodeRepository;
            _taxCalculationService = taxCalculationService;
            _taxServiceFactory = taxServiceFactory;
            _taxCalculationResultRepository = taxCalculationResultRepository;
            _mapper = mapper;
        }

        public async Task<TaxCalculationResponse> Handle(TaxCalculationsCommand request, CancellationToken cancellationToken)
        {
            var postalCodeResponse = await _taxPostalCodeRepository.GetByPostalCodeAsync(request.PostalCode);
            if (postalCodeResponse == null)
            {
                throw new Exception("Postal code not found");
            }
            _taxCalculationService = _taxServiceFactory.CreateTaxService(postalCodeResponse.TaxType.TaxName);
            var taxCalculationResponse = _taxCalculationService.CalculateTax(request.AnnualIncome);

            DateTime dateTime = DateTime.Now;
            var calculatedNett = request.AnnualIncome - taxCalculationResponse;

            //Save to database
            var taxCalculationResult = new TaxCalculationResult
            {
                AnnualIncome = request.AnnualIncome,
                AnnualTax = taxCalculationResponse,
                NettIncome = calculatedNett,
                PostalCode = postalCodeResponse.PostalCode,
                TaxType = postalCodeResponse.TaxType.TaxName,
                DateCreated = dateTime
            };
            await _taxCalculationResultRepository.AddAsync(taxCalculationResult);
            return _mapper.Map<TaxCalculationResponse>(taxCalculationResult);

        }
    }
}
