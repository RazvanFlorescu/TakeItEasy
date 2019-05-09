using System;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.Commands;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using BusinessLogicCommon.Resources;
using BusinessLogicReader.CqrsCore.Queries.User;

namespace TakeItEasyProject.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public UserController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto user)
        {
            GetUserByEmailQuery query = new GetUserByEmailQuery();
            UserDto userByEmail = _dispatcher.Dispatch(query);

            if (userByEmail != null)
            {
                return BadRequest(ResponseMessage.RegisterCommandEmailAlreadyInUse);
            }

            RegisterUserCommand command = new RegisterUserCommand(user);
            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpPost("remove")]
        public IActionResult Remove([FromBody] UserDto user)
        {
            RemoveAccountCommand command = new RemoveAccountCommand(user);
            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllUsersQuery query = new GetAllUsersQuery();
            IList<UserDto> result = _dispatcher.Dispatch(query);

            if (result == null)
            {
                return BadRequest(ResponseMessage.NoUsers);
            }

            return Ok(result);
        }

        [HttpGet("{entityId}")]
        public IActionResult GetUserByEntityId(string entityId)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(entityId, out entityIdParsed))
            {
                return BadRequest();
            }

            GetUserByEntityIdQuery query = new GetUserByEntityIdQuery(entityIdParsed);
            UserDto result = _dispatcher.Dispatch(query);

            if (result == null)
            {
                return BadRequest(ResponseMessage.UserNotFound);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto userDto)
        {
            GetRegisteredUserQuery query = new GetRegisteredUserQuery(userDto.Email, userDto.Password);
            UserDto result = _dispatcher.Dispatch(query);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}