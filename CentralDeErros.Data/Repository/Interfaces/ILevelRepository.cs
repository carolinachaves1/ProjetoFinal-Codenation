using CentralDeErros.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Data.Repository.Interfaces
{
    public interface ILevelRepository
    {
        Level LevelByName(string name);
    }
}
