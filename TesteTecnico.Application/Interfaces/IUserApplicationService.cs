using System.Threading.Tasks;
using TesteTecnico.Application.ViewModels.Address;
using TesteTecnico.Application.ViewModels.User;

namespace TesteTecnico.Application.Interfaces
{
    public interface IUserApplicationService
    {
        Task<SignupViewModel> CreateUser(SignupViewModel user);

        Task<CreateOrEditAddressViewModel> CreateOrEditAddress(string userId, CreateOrEditAddressViewModel viewModel);
    }
}
