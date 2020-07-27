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
        IEnumerable<ErrorDTO> GetByLevel(int level);
        IEnumerable<ErrorDTO> GetByCategory(int category);
        ErrorDTO GetById(int id);
        Error Save(ErrorDTO error);
    }
}
