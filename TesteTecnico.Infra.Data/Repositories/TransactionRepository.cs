using TesteTecnico.Domain.Core.Interfaces.Repositories;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Infra.Data.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
