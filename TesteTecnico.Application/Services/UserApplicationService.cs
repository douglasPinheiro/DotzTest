using AutoMapper;
using System.Threading.Tasks;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.ViewModels.User;
using TesteTecnico.Domain.Core.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserApplicationService(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<SignupViewModel> CreateUser(SignupViewModel userModel)
        {
            var userEntity = _mapper.Map<User>(userModel);
            var user = await _userService.CreateUser(userEntity, userModel.Password);
            return _mapper.Map<SignupViewModel>(user);
        }
    }
}
