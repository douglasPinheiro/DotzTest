using TesteTecnico.Domain.Core.Interfaces.Repositories;

namespace TesteTecnico.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAddressRepository Adresses { get; }
        IWalletRepository Wallets { get; }
        void SaveChanges();
    }
}
