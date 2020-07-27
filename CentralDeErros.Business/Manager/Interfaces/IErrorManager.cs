using CentralDeErros.Business.Models;
using CentralDeErros.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Manager.Interfaces
{
    public interface IErrorManager
    {
        IEnumerable<ErrorDTO> GetAll();
        IEnumerable<ErrorDTO> GetByLevel(string level);
        IEnumerable<ErrorDTO> GetByCategory(string category);
        ErrorDTO GetById(int id);
        Error Save(ErrorDTO error);
    }
}
