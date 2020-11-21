using System.Threading.Tasks;
using TesteTecnico.Application.ViewModels.User;

namespace TesteTecnico.Application.Interfaces
{
    public interface IUserApplicationService
    {
        Task<SignupViewModel> CreateUser(SignupViewModel user);
    }
}
