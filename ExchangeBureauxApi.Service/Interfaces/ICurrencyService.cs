using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;

namespace ExchangeBureauxApi.Service.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyExchange> GetCurrencyByIdentifierAsync(string identifier);
    }
}
