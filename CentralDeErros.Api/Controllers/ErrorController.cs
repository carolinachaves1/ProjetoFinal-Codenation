using System;
using System.Collections.Generic;
using CentralDeErros.Business.Exceptions;
using CentralDeErros.Business.Manager.Interfaces;
using CentralDeErros.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Api.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
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
            catch (ErrorNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ErrorDTO>> GetById([FromRoute] int id)
        {
            try
            {
                var response = _errorManager.GetById(id);

                return Ok(response);
            }
            catch (ErrorNotFoundException)
            {
                return NotFound("Error not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<ErrorDTO> Create(ErrorDTO error)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _errorManager.Save(error);

                return Ok();
            }
            catch (LevelNotFoundException)
            {
                return BadRequest("Level does not exist");
            }
            catch (CategoryNotFoundException)
            {
                return BadRequest("Category does not exist");
            }
        }
    }
}

