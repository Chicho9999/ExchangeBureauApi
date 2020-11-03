﻿using System;
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

        // GET: api/CurrencyExchanges
        [HttpGet]
        public async Task<ActionResult<CurrencyExchange>> GetCurrency(string identifier)
        {
            try
            {
                var currency = await _currencyService.GetCurrencyByIdentifierAsync(identifier);

                var date = currency.UpdatedDate ?? currency.CreatedDate;
                var message = $"Actualiza el dia {date}";
                
                return Ok(new[]
                {
                    currency.ConversionValue.ToString(CultureInfo.InvariantCulture),
                    currency.InverseConversionValue.ToString(CultureInfo.InvariantCulture),
                    message
                });

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                _logger.LogError(e, "Please insert a value in the currency input 'Currency'");

                //this could be done better, automatically when logError is called
                await _logService.Save(new Log()
                    {
                        Aplication = "ExchangeBureauxApi",
                        Message = "Please insert a value in the currency input 'Currency'",
                        CreatedDate = DateTime.Now,
                        Exception = typeof(NullReferenceException).FullName,
                        Level = 3, //Error
                        CreatedBy = 1 //Current User
                    }
                );
                return NotFound("Please insert a value in the currency input 'Currency'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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

        [HttpGet]
        public async Task<ActionResult<CurrencyExchange>> MakeTransaction([FromBody] TransactionVm transactionVm)
        {
            var transaction1 = _mapper.Map<Transaction>(transactionVm);

            await _transactionService.Save(transaction1);

            return Ok();
        }
    }
}