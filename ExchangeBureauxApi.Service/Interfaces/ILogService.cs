using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;

namespace ExchangeBureauxApi.Service.Interfaces
{
    public interface ILogService
    {
        Task Save(Log log);
    }
}
