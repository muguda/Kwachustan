using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Application.Queries.PostalCode;
using TaxCalculator.Models.Dto;



namespace TaxCalculator.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class TaxPostalCodeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaxPostalCodeController(IMediator mediator) => _mediator = mediator;



        /// <summary>
        /// Get all TaxPostalCode
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TaxPostalCodeResponse>> Get() => await _mediator.Send(new TaxPostalCodeQuery());


    }
}
