using CentralDeErros.Business.Models;
using CentralDeErros.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Manager.Interfaces
{
    public interface ILevelManager
    {
        Level LevelByName(string name);
    }
}
