using System.Threading.Tasks;
using TesteTecnico.Application.ViewModels.Transaction;

namespace TesteTecnico.Application.Interfaces
{
    public interface ITransactionApplicationService
    {
        Task Buy(string userEmail, BuyViewModel viewModel);

        Task Exchange(string userEmail, ExchangeViewModel viewModel);
    }
}
