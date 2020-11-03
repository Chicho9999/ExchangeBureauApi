using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;

namespace ExchangeBureauxApi.Service.Interfaces
{
    public interface ITransactionService
    {
        Task Save(Log log);
    }
}
