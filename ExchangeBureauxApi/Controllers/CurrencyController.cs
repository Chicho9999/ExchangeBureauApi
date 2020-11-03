using System;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ExchangeBureauxApi.Service.Interfaces;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.ViewModels;
using Microsoft.Extensions.Logging;

namespace ExchangeBureauxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly ILogger _logger;
        private readonly ILogService _logService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public CurrencyController(
            ICurrencyService currencyService,
            ILogger logger,
            ILogService logService,
            ITransactionService transactionService,
            IMapper mapper
            )
        {
            _currencyService = currencyService;
            _logger = logger;
            _logService = logService;
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getcurrency")]
        public async Task<ActionResult> GetCurrency(string identifier)
        {

            var currency = await _currencyService.GetCurrencyByIdentifierAsync(identifier);

            if (currency == null)
            {
                return NotFound();
            }

            var date = currency.UpdatedDate ?? currency.CreatedDate;
            var message = $"Actualiza el dia {date}";

            return Ok(new[]
            {
                    currency.ConversionValue.ToString(CultureInfo.InvariantCulture),
                    currency.InverseConversionValue.ToString(CultureInfo.InvariantCulture),
                    message
            });
        }

        [HttpPost]
        [Route("maketransaction")]
        public async Task<ActionResult> PostMakeTransaction([FromBody]TransactionVm transactionVm)
        {
            //var transaction = _mapper.Map<Transaction>(transactionVm);
            var transaction = new Transaction()
            {
                AmountConverted = transactionVm.AmountToConvert,
                UserId = transactionVm.UserId
            };

            await _transactionService.Save(transaction, transactionVm.CurrencyIdentifier);

            return Ok();
        }
    }
}