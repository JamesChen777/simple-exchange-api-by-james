using SimpleExchangeAPI.Models;
namespace SimpleExchangeAPI.Services
{
    public interface ISimpleExchangeService
    {
        Task<bool> ConvertAsync(SimpleExchangeModel simpleExchangeModel);
    }
}
