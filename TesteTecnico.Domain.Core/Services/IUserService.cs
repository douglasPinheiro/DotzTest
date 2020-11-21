using System.Threading.Tasks;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Core.Services
{
    public interface IUserService
    {
        Task<bool> DoLogin(string email, string password);

        Task<User> GetUserByEmail(string email);

        Task<User> CreateUser(User user, string password);

        User CreateOrEditAddress(User user, Address address);
    }
}
