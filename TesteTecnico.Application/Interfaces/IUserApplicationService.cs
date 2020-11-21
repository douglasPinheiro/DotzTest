using System.Threading.Tasks;
using TesteTecnico.Application.ViewModels.Address;
using TesteTecnico.Application.ViewModels.User;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Application.Interfaces
{
    public interface IUserApplicationService
    {
        Task<SignupViewModel> CreateUser(SignupViewModel user);

        Task<User> CreateOrEditAddress(string userId, CreateOrEditAddressViewModel viewModel);
    }
}
