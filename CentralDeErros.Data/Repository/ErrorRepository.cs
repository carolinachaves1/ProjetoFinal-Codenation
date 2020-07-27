using CentralDeErros.Data.Models;
using CentralDeErros.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErros.Data.Repository
{
    public class ErrorRepository : IErrorRepository
    {
        private readonly CentralDeErrosContext _context;

        public ErrorRepository(CentralDeErrosContext context)
        {
            _context = context;
        }

        public IEnumerable<Error> GetAll()
        {
            return _context.Errors.Include(x => x.Category)
                .Include(x => x.Level).ToList();
        }

        public IEnumerable<Error> GetByCategory(string category)
        {
            return _context.Errors.Where(x => x.Category.Name == category).ToList();
        }
         
        public Error GetById(int id)
        {
            return _context.Errors.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Error> GetByLevel(string level)
        {
            return _context.Errors.Where(x => x.Level.Name == level).ToList();
        }

        public int Save(Error error)
        {
            _context.Errors.Add(error);
            return _context.SaveChanges();
        }
    }
}
