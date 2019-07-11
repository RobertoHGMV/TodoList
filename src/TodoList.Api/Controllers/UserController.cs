using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.ViewModels;
using TodoList.Domain.Commands.Inputs.User;
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
                return BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Docs = ex });
            }
        }

        [HttpGet, Route("v1/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var person = _service.GetByKey(id);
                if (person is null)
                    return NotFound(new ResultViewModel { Success = false, Message = $"Usuário com [{id}] não encontrado", Docs = { } });

                return Ok(new ResultViewModel { Success = true, Docs = person });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Docs = ex });
            }
        }

        [HttpPost, Route("v1/[controller]")]
        public IActionResult Add(AddUserInput user)
        {
            try
            {
                var userInput = _service.Add(user);
                if (userInput.Invalid)
                    return BadRequest(new ResultViewModel { Success = false, Docs = userInput.Notifications });

                return Created($"v1/people/{userInput.Id}", new ResultViewModel { Success = true, Docs = userInput });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Docs = ex });
            }
        }

        [HttpPut, Route("v1/[controller]")]
        public IActionResult Update(UpdateUserInput user)
        {
            try
            {
                var userUpdate = _service.Update(user);
                if (userUpdate.Invalid)
                    return BadRequest(new ResultViewModel { Success = false, Docs = userUpdate.Notifications });

                return Ok(new ResultViewModel { Success = true, Docs = userUpdate });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Docs = ex });
            }
        }

        [HttpDelete, Route("v1/[controller]/{id}")]
        public IActionResult Update(int id)
        {
            try
            {
                _service.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Docs = ex });
            }
        }
    }
}