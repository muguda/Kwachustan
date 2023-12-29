namespace TaxCalculator.Tests
{
    [TestFixture]
    public class FlatRateTaxServiceTest
    {
        private TaxServiceFactory _taxServiceFactory;
        private ITaxCalculationService _taxCalculationService;

        [SetUp]
        public void Setup()
        {
            _taxServiceFactory = new TaxServiceFactory();
            _taxCalculationService = _taxServiceFactory.CreateTaxService("Flat Rate");
        }


        [Test]
        public void FlatRateTaxServiceWhenAnnualIncomeIs1000_ReturnsFlatRateTax()
        {
            // Arrange
            var annualIncome = 1000;
            var expectedTax = 175;

            // Act
            var actualTax = _taxCalculationService.CalculateTax(annualIncome);

            // Assert
            Assert.AreEqual(expectedTax, actualTax);
        }

        [Test]
        public void FlatRateTaxServiceWhenAnnualIncomeIs10000_ReturnsFlatRateTax()
        {
            // Arrange
            var annualIncome = 10000;
            var expectedTax = 1750;

            // Act
            var actualTax = _taxCalculationService.CalculateTax(annualIncome);

            // Assert
            Assert.AreEqual(expectedTax, actualTax);
        }

        [Test]
        public void FlatRateTaxServiceWhenAnnualIncomeIs100000_ReturnsFlatRateTax()
        {
            // Arrange
            var annualIncome = 100000;
            var expectedTax = 17500;

            // Act
            var actualTax = _taxCalculationService.CalculateTax(annualIncome);

            // Assert
            Assert.AreEqual(expectedTax, actualTax);
        }

        [Test]
        public void FlatRateTaxServiceWhenAnnualIncomeIs1000000_ReturnsFlatRateTax()
        {
            // Arrange
            var annualIncome = 1000000;
            var expectedTax = 175000;

            // Act
            var actualTax = _taxCalculationService.CalculateTax(annualIncome);

            // Assert
            Assert.AreEqual(expectedTax, actualTax);
        }
    }
}
