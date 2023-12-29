using TaxCalculator.Application.Commands.TaxCalculations;

namespace TaxCalculator.Tests.Application.Commands
{
    [TestFixture]
    public class TaxCalculationsCommandHandlerTests
    {

        private Mock<ITaxPostalCodeRepository> _taxPostalCodeRepositoryMock;
        private Mock<ITaxCalculationResultRepository> _taxCalculationResultRepositoryMock;
        private TaxCalculationsCommandHandler _taxCalculationsCommandHandler;
        private TaxServiceFactory _taxServiceFactory;
        private ITaxCalculationService _taxCalculationService;

        [SetUp]
        public void Setup()
        {

            //Configure mapping just for this test
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaxCalculationResult, TaxCalculationResponse>()
             .ForCtorParam(nameof(TaxCalculationResponse.DateCreated), opt => opt.MapFrom(src => src.DateCreated))
             .ForCtorParam(nameof(TaxCalculationResponse.PostalCode), opt => opt.MapFrom(src => src.PostalCode))
             .ForCtorParam(nameof(TaxCalculationResponse.CalculatedTax), opt => opt.MapFrom(src => src.AnnualTax))
             .ForCtorParam(nameof(TaxCalculationResponse.CalculatedNett), opt => opt.MapFrom(src => src.NettIncome))
             .ForCtorParam(nameof(TaxCalculationResponse.TaxType), opt => opt.MapFrom(src => src.TaxType))
             .ForCtorParam(nameof(TaxCalculationResponse.AnnualAmount), opt => opt.MapFrom(src => src.AnnualIncome));
            });

            var mapper = config.CreateMapper();

            _taxServiceFactory = new TaxServiceFactory();
            _taxCalculationService = _taxServiceFactory.CreateTaxService("Progressive");
            _taxPostalCodeRepositoryMock = new Mock<ITaxPostalCodeRepository>();
            _taxCalculationResultRepositoryMock = new Mock<ITaxCalculationResultRepository>();
            _taxCalculationsCommandHandler = new TaxCalculationsCommandHandler(_taxPostalCodeRepositoryMock.Object,
                               _taxCalculationResultRepositoryMock.Object,
                                              _taxCalculationService, mapper,
                                                                            _taxServiceFactory);
        }

        [Test]
        public async Task Handle_WhenPostalCodeNotFound_ThrowsException()
        {
            //Arrange
            _taxPostalCodeRepositoryMock.Setup(x => x.GetByPostalCodeAsync(It.IsAny<string>())).ReturnsAsync((TaxPostalCode)null);

            //Assert
            Assert.ThrowsAsync<Exception>(async () => await _taxCalculationsCommandHandler.Handle(new TaxCalculationsCommand(), new CancellationToken()));
        }



        [Test]
        public async Task Handle_WhenPostalCodeFound_ReturnsTaxCalculationResponse()
        {
            var annualIncome = 20000m;
            var expectedTax = 2582.5m;
            //Arrange
            var taxPostalCode = new TaxPostalCode
            {
                PostalCode = "7441",
                TaxType = new TaxType
                {
                    TaxName = "Progressive"
                }
            };

            _taxPostalCodeRepositoryMock.Setup(x => x.GetByPostalCodeAsync(It.IsAny<string>())).ReturnsAsync(taxPostalCode);
            _taxCalculationResultRepositoryMock.Setup(x => x.AddAsync(It.IsAny<TaxCalculationResult>())).ReturnsAsync(new TaxCalculationResult());

            //Act
            var result = await _taxCalculationsCommandHandler.Handle(new TaxCalculationsCommand { AnnualIncome = annualIncome, PostalCode = taxPostalCode.PostalCode }, new CancellationToken());

            //Assert

            Assert.IsNotNull(result);
            Assert.Multiple(() =>
            {
                Assert.That(result.AnnualAmount, Is.EqualTo(annualIncome));
                Assert.That(result.CalculatedNett, Is.EqualTo(annualIncome - expectedTax));
                Assert.That(result.CalculatedTax, Is.EqualTo(expectedTax));
                Assert.That(result.PostalCode, Is.EqualTo(taxPostalCode.PostalCode));
                Assert.That(result.TaxType, Is.EqualTo(taxPostalCode.TaxType.TaxName));
            });
        }

        [Test]
        public async Task Handle_WhenPostalCodeFound_ReturnsTaxCalculationResponseForFlatValueTax()
        {
            var annualIncome = 20000m;
            var expectedTax = 1000m;
            //Arrange
            var taxPostalCode = new TaxPostalCode
            {
                PostalCode = "A100",
                TaxType = new TaxType
                {
                    TaxName = "Flat Value"
                }
            };

            _taxPostalCodeRepositoryMock.Setup(x => x.GetByPostalCodeAsync(It.IsAny<string>())).ReturnsAsync(taxPostalCode);
            _taxCalculationResultRepositoryMock.Setup(x => x.AddAsync(It.IsAny<TaxCalculationResult>())).ReturnsAsync(new TaxCalculationResult());

            //Act
            var result = await _taxCalculationsCommandHandler.Handle(new TaxCalculationsCommand { AnnualIncome = annualIncome, PostalCode = taxPostalCode.PostalCode }, new CancellationToken());

            //Assert

            Assert.IsNotNull(result);
            Assert.That(result.AnnualAmount, Is.EqualTo(annualIncome));
            Assert.That(result.CalculatedNett, Is.EqualTo(annualIncome - expectedTax));
            Assert.That(result.CalculatedTax, Is.EqualTo(expectedTax));
            Assert.That(result.PostalCode, Is.EqualTo(taxPostalCode.PostalCode));
            Assert.That(result.TaxType, Is.EqualTo(taxPostalCode.TaxType.TaxName));

        }

        [Test]
        public async Task Handle_WhenPostalCodeFound_ReturnsTaxCalculationResponseForFlatRateTax()
        {
            var annualIncome = 20000m;
            var expectedTax = 3500m;
            //Arrange
            var taxPostalCode = new TaxPostalCode
            {
                PostalCode = "7000",
                TaxType = new TaxType
                {
                    TaxName = "Flat Rate"
                }
            };

            _taxPostalCodeRepositoryMock.Setup(x => x.GetByPostalCodeAsync(It.IsAny<string>())).ReturnsAsync(taxPostalCode);
            _taxCalculationResultRepositoryMock.Setup(x => x.AddAsync(It.IsAny<TaxCalculationResult>())).ReturnsAsync(new TaxCalculationResult());

            //Act
            var result = await _taxCalculationsCommandHandler.Handle(new TaxCalculationsCommand { AnnualIncome = annualIncome, PostalCode = taxPostalCode.PostalCode }, new CancellationToken());

            //Assert

            Assert.IsNotNull(result);
            Assert.That(result.AnnualAmount, Is.EqualTo(annualIncome));
            Assert.That(result.CalculatedNett, Is.EqualTo(annualIncome - expectedTax));
            Assert.That(result.CalculatedTax, Is.EqualTo(expectedTax));
            Assert.That(result.PostalCode, Is.EqualTo(taxPostalCode.PostalCode));
            Assert.That(result.TaxType, Is.EqualTo(taxPostalCode.TaxType.TaxName));
        }


    }
}
