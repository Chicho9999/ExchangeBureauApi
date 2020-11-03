using ExchangeBureauxApi.Service.Interfaces;
using System.Threading.Tasks;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.Repository.Interfaces;

namespace ExchangeBureauxApi.Service
{
    public class LogService : ILogService 
    {
        private readonly IUow _uow;

        public LogService(IUow uow)
        {
            _uow = uow;
        }

        public Task Save(Log log)
        {
            return _uow.Logs.AddAsync(log);
        }
    }
}