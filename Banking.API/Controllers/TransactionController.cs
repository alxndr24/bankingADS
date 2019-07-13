using Banking.Application.Transactions.Contracts;
using Banking.Application.Transactions.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("transactions")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionApplicationService _transactionApplicationService;

        public TransactionController(ITransactionApplicationService transactionApplicationService)
        {
            _transactionApplicationService = transactionApplicationService;
        }

        [HttpPost("transfer")]
        public IActionResult PerformTransfer([FromBody] NewTransferDto newTransferDto)
        {
            NewTransferResponseDto response = _transactionApplicationService.PerformTransfer(newTransferDto);
            return StatusCode(response.HttpStatusCode, response.StringResponse);
        }

        [HttpPost("transaction")]
        public IActionResult PerformDeposit([FromBody] NewDepositDto newDepositDto)
        {
            NewTransferResponseDto response = _transactionApplicationService.PerformDeposit(newDepositDto);
            return StatusCode(response.HttpStatusCode, response.StringResponse);
        }

    }
}
