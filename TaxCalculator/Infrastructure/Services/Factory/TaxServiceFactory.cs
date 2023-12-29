using TaxCalculator.Infrastructure.Interfaces;

namespace TaxCalculator.Infrastructure.Services.Factory
{
    public class TaxServiceFactory: ITaxServiceFactory
    {

        public ITaxCalculationService CreateTaxService(string taxType)
        {
            switch (taxType)
            {
                case "Flat Value":
                    return new FlatValueTaxService();
                case "Flat Rate":
                    return new FlatRateTaxService();
                case "Progressive":
                    return new ProgressiveTaxService();
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
