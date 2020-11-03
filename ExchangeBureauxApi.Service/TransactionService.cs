using ExchangeBureauxApi.Service.Interfaces;
using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.Repository.Interfaces;

namespace ExchangeBureauxApi.Service
{
    public class TransactionService : ITransactionService 
    {
        private readonly IUow _uow;

        public TransactionService(IUow uow)
        {
            _uow = uow;
        }

        public Task Save(Transaction transaction)
        {
            return _uow.Transactions.AddAsync(transaction);
        }
    }
}