using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.ViewModels.Wallet;
using TesteTecnico.Domain.Core.Interfaces.Services;

namespace TesteTecnico.Application.Services
{
    public class WalletApplicationService : IWalletApplicationService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public WalletApplicationService(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
            var transactions = user.Wallet.TransactionsHistory.OrderByDescending(d => d.CreatedAt).ToList();
            var result = new ExtractViewModel()
            {
                DotzBalance = user.Wallet.DotzBalance,
                HistoryTransactions = transactions.Select(d => _mapper.Map<ExtractItemViewModel>(d))
            };

            return result;
        }
    }
}
