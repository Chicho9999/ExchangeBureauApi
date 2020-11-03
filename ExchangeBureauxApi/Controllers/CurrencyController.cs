using AutoMapper;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.Service.Interfaces;
using ExchangeBureauxApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Threading.Tasks;
using ExchangeBureauxApi.Service.Enums;

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
        public async Task<ActionResult<CurrencyExchange>> GetCurrency(string identifier)
        {
            try
            {
                var currency = await _currencyService.GetCurrencyByIdentifierAsync(identifier);

                var date = currency.UpdatedDate ?? currency.CreatedDate;
                var message = $"Actualiza el dia {date}";

                _logger.LogTrace("Response succeeded");
                return Ok(new[]
                {
                    currency.ConversionValue.ToString(CultureInfo.InvariantCulture),
                    currency.InverseConversionValue.ToString(CultureInfo.InvariantCulture),
                    message
                });

            }
            catch (NullReferenceException e)
            {
                _logger.LogError(e, "Please insert a value in the currency input 'Currency'");

                //this could be done better, automatically when logError is called
                await _logService.Save(new Log()
                {
                    Aplication = "ExchangeBureauxApi",
                    Message = "Please insert a value in the currency input 'Currency'",
                    CreatedDate = DateTime.Now,
                    Exception = typeof(NullReferenceException).FullName,
                    Level = (int) LogTypes.Error,
                    CreatedBy = (int) UserEnum.CurrentUser
                }
                );
                return NotFound("Please insert a value in the currency input 'Currency'");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Critical Error Ocurred in {typeof(CurrencyController)}", this);
                await _logService.Save(new Log()
                {
                    Aplication = "ExchangeBureauxApi",
                    Message = $"Critical Error Ocurred in {typeof(CurrencyController)}",
                    CreatedDate = DateTime.Now,
                    Exception = typeof(Exception).FullName,
                    Level = 5, //Critical
                    CreatedBy = 1 //Current User
                }
                );

                return Problem("Critical Issue Ocurred While your request was handled");
            }
        }

        [HttpPost]
        [Route("maketransaction")]
        public async Task<ActionResult> PostMakeTransaction([FromBody] TransactionVm transactionVm)
        {
            //var transaction = _mapper.Map<Transaction>(transactionVm);
            try
            {
                var transaction = new Transaction()
                {
                    AmountToConvert = transactionVm.AmountToConvert,
                    UserId = transactionVm.UserId
                };

                await _transactionService.Save(transaction, transactionVm.CurrencyIdentifier);

                return Ok(new
                {
                    message = "Transaction Succed"
                });
            }
            catch (ApplicationException applicationException)
            {
                await _logService.Save(new Log()
                {
                    Aplication = "ExchangeBureauxApi",
                    Message = applicationException.Message,
                    CreatedDate = DateTime.Now,
                    Exception = typeof(ApplicationException).FullName,
                    Level = (int) LogTypes.Error,
                    CreatedBy = (int) UserEnum.CurrentUser
                }
                );
                _logger.LogError(applicationException, applicationException.Message);
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Critical Error Ocurred in {typeof(CurrencyController)}", this);
                await _logService.Save(new Log()
                {
                    Aplication = "ExchangeBureauxApi",
                    Message = $"Critical Error Ocurred in {typeof(CurrencyController)}",
                    CreatedDate = DateTime.Now,
                    Exception = typeof(Exception).FullName,
                    Level = (int) LogTypes.Critical, //Critical
                    CreatedBy = (int)UserEnum.CurrentUser //Current User
                }
                );

                return Problem("Critical Issue Ocurred While your request was handled");

            }
        }
    }
}