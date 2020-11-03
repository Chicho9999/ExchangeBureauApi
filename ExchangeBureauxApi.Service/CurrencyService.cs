using ExchangeBureauxApi.Service.Interfaces;
using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.Repository.Interfaces;
using ExchangeBureauxApi.Service.Enums;

namespace ExchangeBureauxApi.Service
{
    public class CurrencyService : ICurrencyService 
    {
        private readonly IUow _uow;

        public CurrencyService(IUow uow)
        {
            _uow = uow;
        }

        public Task<CurrencyExchange> GetCurrencyByIdentifierAsync(string identifier)
        {
            var result = _uow.CurrencyExchanges.GetAsync(exchange => 
                exchange.CurrencyTo.Identifier == identifier && 
                exchange.CurrencyFromId == (int) CurrencyIds.Argentina);

            return result;
        }
    }
}