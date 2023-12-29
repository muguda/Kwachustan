namespace TaxCalculator.Models.Entity
{
    public class TaxPostalCode
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public int TaxTypeId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual TaxType TaxType { get; set; }


    }
}

