using System;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.Commands.Vacations;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TakeItEasyProject.Controllers
{
    [Route("api/vacations")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public VacationController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost("propose")]
        public IActionResult Propose([FromBody] VacationDto vacation)
        {
            ProposeVacationCommand command = new ProposeVacationCommand(
                Guid.NewGuid(), 
                vacation.Title,
                vacation.Image,
                vacation.StartDate,
                vacation.EndDate,
                vacation.StartPoint,
                vacation.Destination
                );

            _dispatcher.Dispatch(command);

            return Ok();
        }

    }
}
