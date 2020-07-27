﻿using CentralDeErros.Data.Models;
using CentralDeErros.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Manager.Interfaces
{

    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category CategoryByName(string name)
        {
           return _categoryRepository.CategoryByName(name);
        }
    }
}
