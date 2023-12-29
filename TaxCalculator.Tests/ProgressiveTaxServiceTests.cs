namespace TaxCalculator.Tests
{
    [TestFixture]
    public class ProgressiveTaxServiceTests
    {

        private TaxServiceFactory _taxServiceFactory;
        private ITaxCalculationService _taxCalculationService;

        [SetUp]
        public void Setup()
        {
            _taxServiceFactory = new TaxServiceFactory();
            _taxCalculationService = _taxServiceFactory.CreateTaxService("Progressive");
        }

        [Test]
        public void ProgressiveTaxService_WhenAnnualIncomeIs0_Returns0()
        {
            var tax = _taxCalculationService.CalculateTax(0);
            Assert.AreEqual(0, tax);
        }

        [Test]
        public void ProgressiveTaxService_WhenAnnualIncomeIs8000_Returns800()
        {
            var annualIncome = 8000;
            var expectedTax = 800;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }

        //test for 20000
        [Test]
        public void ProgressiveTaxService_WhenAnnualIncomeIs20000_Returns2582()
        {
            var annualIncome = 20000;
            var expectedTax = 2582.5m;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }

        //test for 28% tax bracket 161550
        [Test]
        public void ProgressiveTaxService_WhenAnnualIncomeIs161550_Returns38954()
        {
            var annualIncome = 161550;
            var expectedTax = 38954m;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }

        //test for 33% tax bracket 200000
        [Test]
        public void ProgressiveTaxService_WhenAnnualIncomeIs200000_Returns51142()
        {
            var annualIncome = 200000;
            var expectedTax = 51142.5m;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }

        //test for 35% tax bracket 400000
        [Test]
        public void ProgressiveTaxService_WhenAnnualIncomeIs400000_Returns117683()
        {
            var annualIncome = 400000;
            var expectedTax = 117683.5m;
            var tax = _taxCalculationService.CalculateTax(annualIncome);
            Assert.AreEqual(expectedTax, tax);
        }

    }
}
