using System.Linq;
using System.Threading.Tasks;
using ImportRobot.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImportRobot.Services
{
    public class Repository : IRepository
    {
        private CapDbContext _db;

        public Repository(CapDbContext db)
        {
            _db = db;
        }

        int IRepository.GetMaterialsCount() => _db.MainMaterials.Count();
    }
}