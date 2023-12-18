using PC.Context;
using PC.Service.IRepository.Test;
using PC.Utility.Data;

namespace PD.Repositories.Test
{
    public class TestRepository : GenericRepository<Entity.Test.Test>, ITestRepository
    {
        private readonly ApplicationDbContext _context;

        public TestRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
