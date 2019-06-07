using System;
using System.Collections.Generic;
using BusinessLogicCommon.Resources;
using BusinessLogicReader.CqrsCore.Queries.Vacations;
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
            Guid authorIdParsed;
            if (!Guid.TryParse(vacation.AuthorId, out authorIdParsed))
            {
                return BadRequest();
            }

            ProposeVacationCommand command = new ProposeVacationCommand(
                Guid.NewGuid(),
                authorIdParsed,
                vacation.Title,
                vacation.Description,
                vacation.Image,
                vacation.StartDate,
                vacation.EndDate,
                vacation.VacationPoints,
                vacation.AvailableMode
                );

            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpGet("{userId}")]
        public IActionResult GetVacationsByUserId(string userId)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(userId, out entityIdParsed))
            {
                return BadRequest();
            }

            GetVacationsByUserIdQuery query = new GetVacationsByUserIdQuery(entityIdParsed);
            IList<VacationDto> vacations = _dispatcher.Dispatch(query);

            if (vacations == null)
            {
                return BadRequest(ResponseMessage.VacationNotFound);
            }

            foreach (var vacation in vacations)
            {
                Guid vacationEntityIdParsed;
                if (!Guid.TryParse(vacation.EntityId, out vacationEntityIdParsed))
                {
                    return BadRequest();
                }

                GetLocationsByVacationIdQuery locationQuery = new GetLocationsByVacationIdQuery(vacationEntityIdParsed);
                vacation.VacationPoints = _dispatcher.Dispatch(locationQuery);
            }

            return Ok(vacations);
        }
    }
}
