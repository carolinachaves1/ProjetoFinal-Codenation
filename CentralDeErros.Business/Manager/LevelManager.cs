using CentralDeErros.Business.Exceptions;
using CentralDeErros.Data.Models;
using CentralDeErros.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Manager.Interfaces
{

    public class LevelManager : ILevelManager
    {
        private readonly ILevelRepository _levelRepository;

        public LevelManager(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public Level LevelByName(string name)
        {
           var level = _levelRepository.LevelByName(name);

            if(level == null)
            {
                throw new LevelNotFoundException();
            }

            return level;
        }
    }
}
