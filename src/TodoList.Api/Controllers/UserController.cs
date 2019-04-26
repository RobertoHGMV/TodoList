using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.ViewModels;
using TodoList.Domain.Services;

namespace TodoList.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet, Route("v1/[controller]")]
        public IActionResult Get()
        {
            try
            {
                return Ok(new ResultViewModel { Success = true, Docs = _service.GetAll() });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }

        [HttpGet, Route("v1/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var person = _service.GetByKey(id);
                if (person == null)
                    return NotFound(new ResultViewModel { Success = false, Docs = { } });

                return Ok(new ResultViewModel { Success = true, Docs = person });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }
    }
}