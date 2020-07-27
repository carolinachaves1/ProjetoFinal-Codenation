using CentralDeErros.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralDeErros.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CentralDeErrosContext _context;

        public CategoryRepository(CentralDeErrosContext context)
        {
            _context = context;
        }

        public Category CategoryByName(string name)
        {
            return _context.Categories.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
