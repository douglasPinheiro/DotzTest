using System.Threading.Tasks;
using TesteTecnico.Application.ViewModels.Wallet;

namespace TesteTecnico.Application.Interfaces
{
    public interface IWalletApplicationService
    {
        Task<BalanceViewModel> GetBalance(string userEmail);

        Task<ExtractViewModel> GetExtract(string userEmail);
    }
}
