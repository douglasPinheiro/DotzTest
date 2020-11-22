using TesteTecnico.Domain.Core.Interfaces.Repositories;

namespace TesteTecnico.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAddressRepository Adresses { get; }
        IWalletRepository Wallets { get; }
        ICompanyRepository Companies { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        void SaveChanges();
    }
}
