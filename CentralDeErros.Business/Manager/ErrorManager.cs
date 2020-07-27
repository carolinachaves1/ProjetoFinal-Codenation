using CentralDeErros.Business.Models;
using CentralDeErros.Business.Manager.Interfaces;
using System;
using System.Collections.Generic;
using CentralDeErros.Data.Repository.Interfaces;
using AutoMapper;
using System.Linq;
using CentralDeErros.Data.Models;
using CentralDeErros.Data.Repository;

namespace CentralDeErros.Business.Manager
{
    public class ErrorManager : IErrorManager
    {
        private readonly IErrorRepository _errorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILevelRepository _levelRepository;
        private IMapper _mapper;

        public ErrorManager(IErrorRepository errorRepository, ICategoryRepository categoryRepository, ILevelRepository levelRepository, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _categoryRepository = categoryRepository;
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        public IEnumerable<ErrorDTO> GetAll()
        {
            var response = _errorRepository.GetAll();

            if (response == null || !response.Any())
            {
                throw new Exception();
            }

            return response.Select(x => _mapper.Map<ErrorDTO>(x)).ToList();
        }

        public IEnumerable<ErrorDTO> GetByCategory(int category)
        {
            throw new NotImplementedException();
        }

        public ErrorDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ErrorDTO> GetByLevel(int level)
        {
            throw new NotImplementedException();
        }

        public Error Save(ErrorDTO errorDTO)
        {
            var model = _mapper.Map<Error>(errorDTO);

            var category = _categoryRepository.CategoryByName(errorDTO.Category);
            var level = _levelRepository.LevelByName(errorDTO.Level);

            model.Category = category;
            model.Level = level;

            _errorRepository.Save(model);

            return model;
        }
    }
}
