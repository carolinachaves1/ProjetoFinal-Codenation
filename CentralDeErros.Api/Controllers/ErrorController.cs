using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErros.Business.Manager.Interfaces;
using CentralDeErros.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IErrorManager _errorManager;

        public ErrorController(IErrorManager errorManager)
        {
            _errorManager = errorManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ErrorDTO>> Get()
        {
            try
            {
                var response = _errorManager.GetAll();

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ErrorDTO>> GetById([Required] int id)
        {
            try
            {
                var response = _errorManager.GetById(id);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{levelName}")]
        public ActionResult<IEnumerable<ErrorDTO>> GetByLevel([Required] string levelName)
        {
            try
            {
                var response = _errorManager.GetByLevel(levelName);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{categoryName}")]
        public ActionResult<IEnumerable<ErrorDTO>> GetByCategory([Required] string categoryName)
        {
            try
            {
                var response = _errorManager.GetByCategory(categoryName);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<ErrorDTO> Create(ErrorDTO error)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_errorManager.Save(error));
        }
    }
}

