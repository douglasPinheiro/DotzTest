using TesteTecnico.Domain.Core.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Repositories;
using TesteTecnico.Infra.Data.Repositories;

namespace TesteTecnico.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IAddressRepository Adresses { get; private set; }
        public IWalletRepository Wallets { get; private set; }
        public ICompanyRepository Companies { get; private set; }
        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public ISubCategoryRepository SubCategories { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
            Adresses = new AddressRepository(_context);
            Wallets = new WalletRepository(_context);
            Companies = new CompanyRepository(_context);
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            SubCategories = new SubCategoryRepository(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
