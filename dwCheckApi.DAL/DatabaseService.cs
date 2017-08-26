using System.Threading.Tasks;
using dwCheckApi.Persistence;

namespace dwCheckApi.DAL
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DwContext _context;
        public DatabaseService(DwContext context)
        {
            _context = context;
        }
        public bool ClearDatabase()
        {
            var cleared = _context.Database.EnsureDeleted();
            var created = _context.Database.EnsureCreated();
            var entitiesadded = _context.SaveChanges();

            return (cleared && created && entitiesadded == 0);
        }

        public int SeedDatabase()
        {
            return _context.EnsureSeedData();
        }
    }
}