using Microsoft.AspNetCore.Mvc;
using SimpleExchangeAPI.Models;
using SimpleExchangeAPI.Services;

namespace SimpleExchangeAPI.Controllers
{
    [ApiController]
    [Route("ExchangeService")]
    public class SimpleExchangeController : ControllerBase
    {
        private readonly ISimpleExchangeService _simpleExchangeService = new SimpleExchangeService();
        private readonly ILogger<SimpleExchangeController> _logger;

        public SimpleExchangeController(ILogger<SimpleExchangeController> logger)
        {
            _logger = logger; // TBD: Logging logic - Can choose to use Microsoft.Extensions.Logging's logger or others like log4net, nLog, etc., etc.
        }

        [HttpPost]
        public async Task<ActionResult<SimpleExchangeModel>> Index(decimal amount = 5M, string inputCurrency = "AUD", string outputCurrency = "USD")
        {
            //throw new Exception("test exception");

            var simpleExchangeModel = new SimpleExchangeModel
            {
                Amount = amount,
                InputCurrency = inputCurrency,
                OutputCurrency = outputCurrency
            };

            bool result = await _simpleExchangeService.ConvertAsync(simpleExchangeModel);

            return simpleExchangeModel;
        }
    }
}
