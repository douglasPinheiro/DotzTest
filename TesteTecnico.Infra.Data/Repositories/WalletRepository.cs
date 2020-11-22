using TesteTecnico.Domain.Core.Interfaces.Repositories;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Infra.Data.Repositories
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
