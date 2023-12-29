using TaxCalculator.Models.Entity;

namespace TaxCalculator.Models.Dto
{
    public record  TaxCalculationResponse
    ( decimal CalculatedTax, decimal CalculatedNett, string PostalCode, string TaxType, decimal AnnualAmount, DateTime DateCreated);
}


