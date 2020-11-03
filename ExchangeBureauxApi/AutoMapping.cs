using AutoMapper;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.ViewModels;

namespace ExchangeBureauxApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Transaction, TransactionVm>();
            CreateMap<TransactionVm, TransactionVm>();
        }
    }
}
