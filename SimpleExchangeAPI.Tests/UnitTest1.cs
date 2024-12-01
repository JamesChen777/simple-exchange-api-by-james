using Newtonsoft.Json.Linq;
using SimpleExchangeAPI.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleExchangeAPI.Tests
{
    public class Tests
    {
        private readonly string _urlString = "https://open.er-api.com/v6/latest/USD"; // TBD: Put it in resource or config file later if needed
        private readonly string _aud = "AUD";
        private readonly string _usd = "USD";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestConvertAsync()
        {
            var simpleExchangeController = new SimpleExchangeController(null); // Logging yet needs to be implemented for main logic so pass in a null
            var res = await simpleExchangeController.Index(5, _aud, _usd);
            double? rate = (double?)(res.Value?.Amount / res.Value?.Value);
            double? realRate = await GetRateAsync();
            double? diff = rate - realRate; // Get the diff as there are precision issue with double, especially relatively large on 2 decimal positions in this case
            if(diff < -0.01 || diff > 0.01) // If diff is out of a small range, then fail
            {
                Assert.Fail(); // TBD: Can add a proper message here in the overloaded Fail() method if you need
            }
            Assert.Pass();
        }

        private async Task<double?> GetRateAsync()
        {
            using (var client = new HttpClient())
            {
                var responseBody = await client.GetStringAsync(new Uri(_urlString));
                double? rate = JObject.Parse(responseBody)["rates"]?["AUD"]?.ToObject<double>();
                return rate;
            }
        }
    }
}