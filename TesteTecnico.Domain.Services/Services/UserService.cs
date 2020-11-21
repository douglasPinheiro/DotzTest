using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico.Domain.Core.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> CreateUser(User user, string password)
        {
            user.IsActive = true;
            var result = await _userManager.CreateAsync(user, password);
            ThrowExceptionOnError(result);
            return user;
        }

        public async Task<bool> DoLogin(string email, string password)
        {
            var user = await this.GetUserByEmail(email);
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        private void ThrowExceptionOnError(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                string errorMessage = string.Join("\n", result.Errors.Select(d => $"code: {d.Code}, errorMessage: {d.Description}").ToList());
                throw new Exception(errorMessage);
            }
        }
    }
}
