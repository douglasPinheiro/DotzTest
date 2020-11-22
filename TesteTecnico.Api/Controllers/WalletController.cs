using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TesteTecnico.Application.Interfaces;

namespace TesteTecnico.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletApplicationService _walletApplicationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WalletController(IWalletApplicationService walletApplicationService,
            IHttpContextAccessor httpContextAccessor)
        {
            _walletApplicationService = walletApplicationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("Balance")]
        public async Task<IActionResult> Balance()
        {
            string userEmail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _walletApplicationService.GetBalance(userEmail));
        }

        [HttpGet("Extract")]
        public async Task<IActionResult> Extract()
        {
            string userEmail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _walletApplicationService.GetExtract(userEmail));
        }
    }
}
