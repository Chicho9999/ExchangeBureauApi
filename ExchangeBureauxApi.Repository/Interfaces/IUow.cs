using System;
using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;

namespace ExchangeBureauxApi.Repository.Interfaces
{
    public interface IUow : IDisposable
    {
        IRepository<Currency> Currencies { get; }
        IRepository<CurrencyExchange> CurrencyExchanges { get; }
        IRepository<User> Users { get; }
        IRepository<Log> Logs { get; }
        IRepository<Transaction> Transactions { get; }

        void Commit();
        Task CommitAsync();
        Task DisposeAsync();
    }
}
