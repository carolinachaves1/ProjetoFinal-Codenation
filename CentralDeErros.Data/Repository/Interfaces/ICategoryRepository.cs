using CentralDeErros.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Data.Repository
{
    public interface ICategoryRepository
    {
        Category CategoryByName(string name);
    }
}
