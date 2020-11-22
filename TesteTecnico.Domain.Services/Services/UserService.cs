using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico.Domain.Core.Interfaces;
using TesteTecnico.Domain.Core.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<User> userManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public User CreateOrEditAddress(User user, Address address)
        {
            address.CreatedAt = DateTime.Now;
            _unitOfWork.Adresses.Add(address);

            if(user.Address != null && user.Address.Id > 0)
            {
                user.Address.IsActive = false;
                user.Address.UpdatedAt = DateTime.Now;
            }

            user.Address = address;
            _unitOfWork.SaveChanges();

            return user;
        }

        public async Task<User> CreateUser(User user, string password)
        {
            user.IsActive = true;
            var result = await _userManager.CreateAsync(user, password);
            ThrowExceptionOnError(result);
            user.Wallet = CreateInitialWallet(user);
            result = await _userManager.UpdateAsync(user);
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

        private Wallet CreateInitialWallet(User user)
        {
            var initialWallet = new Wallet() { DotzBalance = 0, User = user };
            _unitOfWork.Wallets.Add(initialWallet);
            _unitOfWork.SaveChanges();

            return initialWallet;
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
