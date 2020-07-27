using System;
using System.Collections.Generic;
using CentralDeErros.Business.Manager.Interfaces;
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
        public ActionResult<IEnumerable<Business.Models.ErrorDTO>> Get()
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

        [HttpPost]
        public ActionResult<Business.Models.ErrorDTO> Create(Business.Models.ErrorDTO error)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _errorManager.Save(error);

            return Ok();
        }
    }
}
