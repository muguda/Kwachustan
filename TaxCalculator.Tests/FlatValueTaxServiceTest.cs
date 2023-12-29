namespace TaxCalculator.Tests
{
    [TestFixture]
    public class FlatValueTaxServiceTest
    {
        private TaxServiceFactory _taxServiceFactory;
        private ITaxCalculationService _taxCalculationService;

        [SetUp]
        public void Setup()
        {
            _taxServiceFactory = new TaxServiceFactory();
            _taxCalculationService = _taxServiceFactory.CreateTaxService("Flat Value");

        }


        [Test]
        public void FlatValueTaxService_WhenAnnualIncomeIs1000_Returns50()
        {
            var annualIncome = 1000;
            var expectedTax = 50;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }

        // amount greater than 200000
        [Test]
        public void FlatValueTaxService_WhenAnnualIncomeIs300000_Returns10000()
        {
            var annualIncome = 300000;
            var expectedTax = 10000;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }

        [Test]
        public void FlatValueTaxService_WhenAnnualIncomeIs0_Returns0()
        {
            var annualIncome = 0;
            var expectedTax = 0;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }

        [Test]
        public void FlatValueTaxService_WhenAnnualIncomeIsNegative_Returns0()
        {
            var annualIncome = -1000;
            var expectedTax = 0;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }
    }
}
