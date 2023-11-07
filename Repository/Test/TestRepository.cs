using Context;
using Service.IRepository.Test;
using Utility.Data;

namespace Repositories.Test
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
