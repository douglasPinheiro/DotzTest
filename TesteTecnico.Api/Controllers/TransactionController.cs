using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.ViewModels.Transaction;

namespace TesteTecnico.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITransactionApplicationService _transactionApplicationService;

        public TransactionController(IHttpContextAccessor httpContextAccessor,
            ITransactionApplicationService transactionApplicationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _transactionApplicationService = transactionApplicationService;
        }

        [HttpPost("Buy")]
        public IActionResult Buy(BuyViewModel viewModel)
        {
            string userEmail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _transactionApplicationService.Buy(userEmail, viewModel);
            return Ok();
        }

        [HttpPost("Exchange")]
        public async Task<IActionResult> Exchange(ExchangeViewModel viewModel)
        {
            string userEmail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _transactionApplicationService.Exchange(userEmail, viewModel);
            return Ok();
        }
    }
}
