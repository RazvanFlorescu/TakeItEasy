using System;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.Commands;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using BusinessLogicCommon.Resources;
using BusinessLogicReader.CqrsCore.Queries.Users;
using BusinessLogicWriter.CqrsCore.Commands.Users;
using System.Security.Cryptography;
using System.Text;

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
            GetUserByEmailQuery query = new GetUserByEmailQuery(user.Email);
            UserDto userByEmail = _dispatcher.Dispatch(query);

            if (userByEmail != null)
            {
                return BadRequest(ResponseMessage.RegisterCommandEmailAlreadyInUse);
            }

            RegisterUserCommand command = new RegisterUserCommand(user.FirstName, user.LastName,
            user.Email, GetMd5Hash(user.Password), user.Image, Guid.NewGuid());
            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpPost("remove")]
        public IActionResult Remove([FromBody] UserDto user)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(user.EntityId, out entityIdParsed))
            {
                return BadRequest(ResponseMessage.UserIncorectId);
            }

            RemoveAccountCommand command = new RemoveAccountCommand(user.FirstName, user.LastName, 
                user.Email, user.Password, user.Image, entityIdParsed);
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
            GetRegisteredUserQuery query = new GetRegisteredUserQuery(userDto.Email, GetMd5Hash(userDto.Password));
            UserDto result = _dispatcher.Dispatch(query);

            if (result == null)
            {
                return BadRequest(ResponseMessage.UserNotFound);
            }

            return Ok(result);
        }

        private static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}