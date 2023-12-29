namespace TaxCalculator.Models.Entity
{
    public class TaxCalculationResult
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string TaxType { get; set; }
        public decimal AnnualIncome { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualTax { get; set; }
        public decimal NettIncome { get; set; }

    }
}
