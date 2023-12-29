namespace TaxCalculator.Models.Entity
{
    public class TaxTable
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int TaxTypeId { get; set; }
        public decimal Rate { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateDisabled { get; set; }
        public decimal TaxValue { get; set; }

        public virtual TaxType TaxType { get; set; }


    }
}

