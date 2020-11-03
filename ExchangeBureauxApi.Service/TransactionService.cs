using System;
using ExchangeBureauxApi.Service.Interfaces;
using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.Repository.Interfaces;
using ExchangeBureauxApi.Service.Enums;

namespace ExchangeBureauxApi.Service
{
    public class TransactionService : ITransactionService 
    {
        private readonly IUow _uow;

        public TransactionService(IUow uow)
        {
            _uow = uow;
        }

        public Task Save(Transaction transaction, string transactionVmCurrencyIdentifier)
        {
            if (transaction.AmountToConvert < 500)
            {
                throw new ApplicationException("The amount of money must be greater than 500");
            }

            var result = _uow.CurrencyExchanges.Get(exchange =>
                exchange.CurrencyTo.Identifier == transactionVmCurrencyIdentifier &&
                exchange.CurrencyFromId == (int)CurrencyIds.Argentina);

            var crrncyConverted = transaction.AmountToConvert / result.ConversionValue;

            var limitPermited = _uow.LimitPucharses.Get(pucharse => 
                pucharse.CurrencyId == result.CurrencyToId &&
                pucharse.UserId == 1 //CurrentUser
                );

            if (limitPermited == null)
            {
                throw new ApplicationException("The user or currency doesn't exist");
            }

            if (crrncyConverted > limitPermited.MaxAmountToBuy)
            {
                throw new ApplicationException("You cant perform this transaction because you passes the maximun posible");
            }

            limitPermited.MaxAmountToBuy -= crrncyConverted;

            _uow.LimitPucharses.Update(limitPermited);

            _uow.Transactions.AddAsync(transaction);

            return _uow.CommitAsync();
        }
    }
}