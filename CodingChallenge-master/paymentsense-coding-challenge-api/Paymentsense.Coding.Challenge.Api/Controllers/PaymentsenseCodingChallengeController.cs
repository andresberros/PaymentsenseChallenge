using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsenseCodingChallengeController : ControllerBase
    {
        private readonly IPaymentsenseCodingChallengeService _service;

        public PaymentsenseCodingChallengeController(IPaymentsenseCodingChallengeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            try
            {
                var result = await _service.GetCountries();

                if (result != null && result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No countries have been found");
                }
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
