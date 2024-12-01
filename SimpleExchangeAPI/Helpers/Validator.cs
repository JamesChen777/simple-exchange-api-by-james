using SimpleExchangeAPI.Models;

namespace SimpleExchangeAPI.Helpers
{
    public class Validator
    {
        public ValidationResult Result;
        public string? ErrMsg;

        /// <summary>
        /// Simple Validator to validate client input parameters
        /// </summary>
        /// <param name="simpleExchangeModel"></param>
        public Validator(SimpleExchangeModel simpleExchangeModel)
        {
            Result = ValidationResult.Failure;
            if (simpleExchangeModel.Amount < 0)
            {
                ErrMsg = "Amount must be equal to or larger than 0";
                return;
            }
            else if ((simpleExchangeModel.InputCurrency = simpleExchangeModel.InputCurrency?.Trim().ToUpper()) != "AUD")
            {
                ErrMsg = "InputCurrency must be 'AUD\'";
                return;
            }
            else if ((simpleExchangeModel.OutputCurrency = simpleExchangeModel.OutputCurrency?.Trim().ToUpper()) != "USD")
            {
                ErrMsg = "OutputCurrency must be 'USD\'";
                return;
            }
            Result = ValidationResult.Success;
        }
    }

    public enum ValidationResult
    {
        Success = 0,
        Failure = 1
    }
}
