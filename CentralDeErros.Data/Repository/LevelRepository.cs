using CentralDeErros.Data.Models;
using CentralDeErros.Data.Repository.Interfaces;
using System.Linq;

namespace CentralDeErros.Data.Repository
{
    public class LevelRepository : ILevelRepository
    {
        private readonly CentralDeErrosContext _context;

        public LevelRepository(CentralDeErrosContext context)
        {
            _context = context;
        }

        public Level LevelByName(string name)
        {
            var level = _context.Levels.Where(x => x.Name == name).FirstOrDefault();

            return level;
        }
    }
}
