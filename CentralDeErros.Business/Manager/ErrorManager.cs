using CentralDeErros.Business.Models;
using CentralDeErros.Business.Manager.Interfaces;
using System;
using System.Collections.Generic;
using CentralDeErros.Data.Repository.Interfaces;
using AutoMapper;
using System.Linq;
using CentralDeErros.Data.Models;
using CentralDeErros.Data.Repository;
using CentralDeErros.Business.Exceptions;

namespace CentralDeErros.Business.Manager
{
    public class ErrorManager : IErrorManager
    {
        private readonly IErrorRepository _errorRepository;
        private readonly ICategoryManager _categoryManager;
        private readonly ILevelManager _levelManager;
        private IMapper _mapper;

        public ErrorManager(IErrorRepository errorRepository, ICategoryManager categoryManager, ILevelManager levelManager, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _categoryManager = categoryManager;
            _levelManager = levelManager;
            _mapper = mapper;
        }

        public IEnumerable<ErrorDTO> GetAll()
        {
            var response = _errorRepository.GetAll();

            if (response == null || !response.Any())
            {
                throw new NoContentException();
            }

            return response.Select(x => _mapper.Map<ErrorDTO>(x)).ToList();
        }


        public ErrorDTO GetById(int id)
        {
            var response = _errorRepository.GetById(id);

            if (response == null)
            {
                throw new ErrorNotFoundException();
            }

            return _mapper.Map<ErrorDTO>(response);
        }

        
        public Error Save(ErrorDTO errorDTO)
        {
            try
            {
                var model = _mapper.Map<Error>(errorDTO);

                var category = _categoryManager.CategoryByName(errorDTO.Category);
                var level = _levelManager.LevelByName(errorDTO.Level);

                model.Category = category;
                model.Level = level;

                _errorRepository.Save(model);

                return model;
            }
            catch (LevelNotFoundException)
            {
                throw new LevelNotFoundException();
            }
            catch (CategoryNotFoundException)
            {
                throw new CategoryNotFoundException();
            }

        }
    }
}
