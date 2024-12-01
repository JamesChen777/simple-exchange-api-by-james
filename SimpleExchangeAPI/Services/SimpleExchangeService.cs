using SimpleExchangeAPI.Models;
using SimpleExchangeAPI.Helpers;
using Newtonsoft.Json.Linq;

namespace SimpleExchangeAPI.Services
{
    public class SimpleExchangeService : ISimpleExchangeService
    {
        private readonly string _urlString = "https://open.er-api.com/v6/latest/USD"; // TBD: Put it in resource or config file later if needed

        /// <summary>
        /// Convert entry method
        /// </summary>
        /// <param name="simpleExchangeModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<bool> ConvertAsync(SimpleExchangeModel simpleExchangeModel)
        {
            if (!Validate(simpleExchangeModel, out string? errMsg))
            {
                throw new ArgumentException(errMsg); // Will be caught by global exception handler middleware, and show it to client properly
            }
            simpleExchangeModel.Value = await ConvertAsync(simpleExchangeModel.Amount);
            return true;
        }

        /// <summary>
        /// Convert core method
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private async Task<decimal> ConvertAsync(decimal amount)
        {
            double? rate;
            using (var client = new HttpClient())
            {
                var responseBody = await client.GetStringAsync(new Uri(_urlString));
                rate = JObject.Parse(responseBody)["rates"]?["AUD"]?.ToObject<double>();
            }

            return Decimal.Round(amount / (decimal)rate, 2, MidpointRounding.AwayFromZero); // Returns the calculated value
                                                                                            // Note: If exception thrown on above line (rate == null), will be properly caught and handled by golbal exception handler
        }

        /// <summary>
        /// Validate input parameters in the request from client
        /// </summary>
        /// <param name="simpleExchangeModel"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private bool Validate(SimpleExchangeModel simpleExchangeModel, out string? errMsg)
        {
            errMsg = "";
            var validator = new Validator(simpleExchangeModel);

            switch (validator.Result)
            {
                case ValidationResult.Success:
                    errMsg = ValidationResult.Success.ToString();
                    return true;
                case ValidationResult.Failure:
                    errMsg = validator.ErrMsg;
                    return false;
                default:
                    return false;
            }
        }
    }
}
