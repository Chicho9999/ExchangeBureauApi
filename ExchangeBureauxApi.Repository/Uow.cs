using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.Repository.Interfaces;

namespace ExchangeBureauxApi.Repository
{
    public class Uow : IUow
    {
        private readonly CurrencyExchangeDbContext _DBContext;

        private IRepository<Currency> _Currencies;
        private IRepository<CurrencyExchange> _CurrencyExchanges;
        private IRepository<User> _Users;
        public IRepository<Log> _Logs;
        public IRepository<Transaction> _Transactions;
        public IRepository<LimitPucharse> _LimitPucharses;


        public IRepository<Currency> Currencies => _Currencies ??= new GenericRepository<Currency>(_DBContext);
        public IRepository<CurrencyExchange> CurrencyExchanges => _CurrencyExchanges ??= new GenericRepository<CurrencyExchange>(_DBContext);
        public IRepository<User> Users => _Users ??= new GenericRepository<User>(_DBContext);
        public IRepository<Log> Logs => _Logs ??= new GenericRepository<Log>(_DBContext);
        public IRepository<Transaction> Transactions => _Transactions ??= new GenericRepository<Transaction>(_DBContext);
        public IRepository<LimitPucharse> LimitPucharses => _LimitPucharses ??= new GenericRepository<LimitPucharse>(_DBContext);

        public Uow(CurrencyExchangeDbContext context)
        {
            _DBContext = context;
        }

        public void Commit()
        {
            _DBContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _DBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _DBContext.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _DBContext.DisposeAsync();
        }
    }
}
