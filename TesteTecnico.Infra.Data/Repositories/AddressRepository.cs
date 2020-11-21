using TesteTecnico.Domain.Core.Interfaces.Repositories;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Infra.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
