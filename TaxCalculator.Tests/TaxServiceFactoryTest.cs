namespace TaxCalculator.Tests
{
    [TestFixture]
    public class TaxServiceFactoryTest
    {
        private TaxServiceFactory _taxServiceFactory;
        [SetUp]
        public void SetUp()
        {
            _taxServiceFactory = new TaxServiceFactory();
        }

        [Test]
        public void CreateTaxService_ShouldReturnFlatRateTaxService_WhenTaxTypeIsFlatRate()
        {
            var taxService = _taxServiceFactory.CreateTaxService("Flat Rate");
            Assert.IsInstanceOf<FlatRateTaxService>(taxService);
        }

        [Test]
        public void CreateTaxService_ShouldReturnProgressiveTaxService_WhenTaxTypeIsProgressive()
        {

            var taxService = _taxServiceFactory.CreateTaxService("Progressive");
            Assert.IsInstanceOf<ProgressiveTaxService>(taxService);
        }

        [Test]
        public void CreateTaxService_ShouldReturnFlatValueTaxService_WhenTaxTypeIsFlatValue()
        {

            var taxService = _taxServiceFactory.CreateTaxService("Flat Value");
            Assert.IsInstanceOf<FlatValueTaxService>(taxService);
        }

        [Test]
        public void CreateTaxService_ShouldThrowException_WhenTaxTypeIsNotValid()
        {

            var taxServiceFactory = new TaxServiceFactory();
            Assert.Throws<NotImplementedException>(() => taxServiceFactory.CreateTaxService("InvalidTaxType"));
        }

    }
}
