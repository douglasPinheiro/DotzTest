using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TesteTecnico.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        public TransactionController()
        {
        }

        [HttpPost("Buy")]
        public IActionResult Buy()
        {
            return Ok();
        }
    }
}
