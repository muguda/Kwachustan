

namespace TaxCalculator.Tests.Application.Queries
{
    [TestFixture]
    public class TaxPostalCodeQueryHandlerTests
    {
        private Mock<IMapper> _mapper;
        private Mock<ITaxPostalCodeRepository> _taxPostalCodeRepository;
        private TaxPostalCodeQueryHandler _taxPostalCodeQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _mapper = new Mock<IMapper>();
            _taxPostalCodeRepository = new Mock<ITaxPostalCodeRepository>();
            _taxPostalCodeQueryHandler = new TaxPostalCodeQueryHandler(_mapper.Object, _taxPostalCodeRepository.Object);
        }

        [Test]
        public async Task TaxPostalCodeQueryHandler_ShouldReturnTaxPostalCodeResponse()
        {
            //Arrange
            var taxPostalCode = new TaxPostalCode
            {
                Id = 1,
                PostalCode = "7441",
                TaxType = new TaxType
                {
                    TaxName = "Progressive"
                }
            };
            var taxPostalCodes = new List<TaxPostalCode> { taxPostalCode };
            _taxPostalCodeRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(taxPostalCodes);
            var taxPostalCodeResponse = new TaxPostalCodeResponse("7441", "Progressive");
            var taxPostalCodeResponses = new List<TaxPostalCodeResponse> { taxPostalCodeResponse };
            _mapper.Setup(x => x.Map<List<TaxPostalCodeResponse>>(taxPostalCodes)).Returns(taxPostalCodeResponses);

            //Act
            var result = await _taxPostalCodeQueryHandler.Handle(new TaxPostalCodeQuery(), CancellationToken.None);

            //Assert
            Assert.AreEqual(taxPostalCodeResponses, result);
        }


        [Test]
        public async Task TaxPostalCodeQueryHandler_ShouldReturnTaxPostalCodeResponse_WhenMoreThanOnePostalCode()
        {
            //Arrange
            var taxPostalCode = new TaxPostalCode
            {
                Id = 1,
                PostalCode = "7441",
                TaxType = new TaxType
                {
                    TaxName = "Progressive"
                }
            };
            var taxPostalCode2 = new TaxPostalCode
            {
                Id = 2,
                PostalCode = "A100",
                TaxType = new TaxType
                {
                    TaxName = "Flat Value"
                }
            };
            var taxPostalCodes = new List<TaxPostalCode> { taxPostalCode, taxPostalCode2 };
            _taxPostalCodeRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(taxPostalCodes);
            var taxPostalCodeResponse = new TaxPostalCodeResponse("7441", "Progressive");
            var taxPostalCodeResponse2 = new TaxPostalCodeResponse("A100", "Flat Value");
            var taxPostalCodeResponses = new List<TaxPostalCodeResponse> { taxPostalCodeResponse, taxPostalCodeResponse2 };
            _mapper.Setup(x => x.Map<List<TaxPostalCodeResponse>>(taxPostalCodes)).Returns(taxPostalCodeResponses);

            //Act
            var result = await _taxPostalCodeQueryHandler.Handle(new TaxPostalCodeQuery(), CancellationToken.None);

            //Assert
            Assert.AreEqual(taxPostalCodeResponses, result);
        }

    }
}
