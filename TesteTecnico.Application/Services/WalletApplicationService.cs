using System.Threading.Tasks;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.ViewModels.Wallet;
using TesteTecnico.Domain.Core.Interfaces.Services;

namespace TesteTecnico.Application.Services
{
    public class WalletApplicationService : IWalletApplicationService
    {
        private readonly IUserService _userService;

        public WalletApplicationService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BalanceViewModel> GetBalance(string userEmail)
        {
            var user = await _userService.GetUserByEmail(userEmail);

            return new BalanceViewModel
            {
                DotzBalance = user.Wallet.DotzBalance
            };
        }

        public async Task<ExtractViewModel> GetExtract(string userEmail)
        {
            var user = await _userService.GetUserByEmail(userEmail);
            // TODO: get extract
            return new ExtractViewModel();
        }
    }
}
