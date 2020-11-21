using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.ViewModels.Address;
using TesteTecnico.Application.ViewModels.User;
using TesteTecnico.Domain.Core.Services;

namespace TesteTecnico.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserApplicationService _userApplicationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtTokenService _jwtTokenService;

        public UserController(
            IUserService userService,
            IUserApplicationService userApplicationService,
            IHttpContextAccessor httpContextAccessor,
            IJwtTokenService jwtTokenService)
        {
            _userService = userService;
            _userApplicationService = userApplicationService;
            _httpContextAccessor = httpContextAccessor;
            _jwtTokenService = jwtTokenService;
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<ActionResult<SignupViewModel>> Create(SignupViewModel input)
        {
            var existentUser = await _userService.GetUserByEmail(input.Email);
            if (existentUser != null)
            {
                return BadRequest("This user Already exists");
            }

            return await _userApplicationService.CreateUser(input);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(SigninViewModel input)
        {
            var user = await _userService.GetUserByEmail(input.Email);

            if (user == null)
                return BadRequest(new { error = "", error_description = "Usuario não existe" });

            if (!user.IsActive)
                return BadRequest(new { error = "", error_description = "Usuario não esta ativo" });

            if (!await _userService.DoLogin(user.Email, input.Password))
                return BadRequest(new { error = "", error_description = "Username ou senha inválida" });

            string token = _jwtTokenService.GenerateToken(user);

            return Ok(new { token });
        }

        [Authorize]
        [HttpPut("Endereco")]
        public IActionResult CreateOrEditAddress(CreateOrEditAddressViewModel input)
        {
            string userEmail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _userApplicationService.CreateOrEditAddress(userEmail, input);

            return Ok();
        }
    }
}
