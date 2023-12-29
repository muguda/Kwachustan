namespace TaxCalculator.Infrastructure.Interfaces
{
    public interface ITaxServiceFactory
    {
        ITaxCalculationService CreateTaxService(string taxType);
    }
}
