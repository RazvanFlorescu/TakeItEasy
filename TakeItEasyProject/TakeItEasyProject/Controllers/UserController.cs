using BusinessLogicWriter.CqrsCore;
using BusinessLogicReader.CqrsCore.Queries;
using BusinessLogicWriter.CqrsCore.Commands;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

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

            return Ok(result);
        }
    }
}