using CentralDeErros.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Data.Repository.Interfaces
{
    public interface IErrorRepository
    {
        IEnumerable<Error> GetAll();
        Error GetById(int id);
        IEnumerable<Error> GetByLevel(string level);
        IEnumerable<Error> GetByCategory(string category);
        int Save(Error error);
    }
}
