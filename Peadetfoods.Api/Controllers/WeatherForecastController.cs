using Microsoft.AspNetCore.Mvc;

using PaystackSDK;
using PaystackSDK.Models.Transactions;

namespace Peadetfoods.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPaystackClient _paystackClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPaystackClient paystackClient)
        {
            _logger = logger;
            _paystackClient = paystackClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = await _paystackClient.Transactions.Initialize(new PaystackInitializeTransactionRequest
            {
                Amount = "1000000",
                Email = "coache1234@gmail.com"
            });

            return Ok(result);
        }
    }
}