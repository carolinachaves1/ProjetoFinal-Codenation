using CentralDeErros.Business.Exceptions;
using CentralDeErros.Data.Models;
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
           var category = _categoryRepository.CategoryByName(name);

            if(category == null)
            {
                throw new CategoryNotFoundException();
            }

            return category;
        }
    }
}
