using CentralDeErros.Data.Models;
using CentralDeErros.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return _context.Levels.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
