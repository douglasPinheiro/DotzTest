using TesteTecnico.Domain.Core.Interfaces.Repositories;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Infra.Data.Repositories
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
