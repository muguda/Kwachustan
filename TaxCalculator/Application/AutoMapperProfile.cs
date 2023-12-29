using AutoMapper;
using TaxCalculator.Models.Dto;
using TaxCalculator.Models.Entity;

namespace TaxCalculator.Application
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<TaxPostalCode, TaxPostalCodeResponse>()
             .ForCtorParam(nameof(TaxPostalCodeResponse.TaxType), opt => opt.MapFrom(src => src.TaxType.TaxName));

            CreateMap<TaxCalculationResult, TaxCalculationResponse>()
            .ForCtorParam(nameof(TaxCalculationResponse.DateCreated), opt => opt.MapFrom(src => src.DateCreated))
            .ForCtorParam(nameof(TaxCalculationResponse.PostalCode), opt => opt.MapFrom(src => src.PostalCode))
            .ForCtorParam(nameof(TaxCalculationResponse.CalculatedTax), opt => opt.MapFrom(src => src.AnnualTax))
            .ForCtorParam(nameof(TaxCalculationResponse.CalculatedNett), opt => opt.MapFrom(src => src.NettIncome))
            .ForCtorParam(nameof(TaxCalculationResponse.TaxType), opt => opt.MapFrom(src => src.TaxType))
            .ForCtorParam(nameof(TaxCalculationResponse.AnnualAmount), opt => opt.MapFrom(src => src.AnnualIncome));
        }
    }
}
