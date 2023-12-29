using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Application.Commands.TaxCalculations;
using TaxCalculator.Models.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxCalculator.Controllers.Apis
{
    /// <summary>
    ///  Tax calculator controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaxCalculatorController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Calculate tax
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<TaxCalculationResponse> CalculateTax([FromBody] TaxCalculationRequest request) => await _mediator.Send(new TaxCalculationsCommand { AnnualIncome = request.AnnualIncome, PostalCode = request.PostalCode });


    }
}
