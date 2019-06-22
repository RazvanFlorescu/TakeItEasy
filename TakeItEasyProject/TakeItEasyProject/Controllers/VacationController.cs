using System;
using System.Collections.Generic;
using BusinessLogicCommon.Resources;
using BusinessLogicReader.CqrsCore.Queries.Vacations;
using BusinessLogicReader.CqrsCore.QueryHandlers.Vacations;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.Commands.Vacations;
using BusinessLogicWriter.CqrsCore.Commands.WishList;
using CommonTypes;
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

        [HttpGet]
        public IActionResult GetAllVacations()
        {
            GetAllVacationsQuery query = new GetAllVacationsQuery();
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

        [HttpGet("mostWanted")]
        public IActionResult GetMostWanted()
        {
            GetMostWantedQuery query = new GetMostWantedQuery();
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

        [HttpGet("{userId}/vacationJoinings")]
        public IActionResult GetVacationsByUserIdWhereThatUserIsJoinedThere(string userId)
        {
            Guid userEntityIdParsed;
            if (!Guid.TryParse(userId, out userEntityIdParsed))
            {
                return BadRequest();
            }

            GetVacationsByUserIdWhereThatUserIsJoinedThereQuery query = new GetVacationsByUserIdWhereThatUserIsJoinedThereQuery(userEntityIdParsed);
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

        [HttpPost("addWishItem")]
        public IActionResult AddWishItem([FromBody] WishItemDto wishItem)
        {
            Guid authorIdParsed;
            if (!Guid.TryParse(wishItem.AuthorId, out authorIdParsed))
            {
                return BadRequest();
            }

            AddWishItemCommand command = new AddWishItemCommand(authorIdParsed, wishItem.Location);

            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpPost("join")]
        public IActionResult Join([FromBody] VacationJoiningDto vacation)
        {
            Guid vacationIdParsed;
            if (!Guid.TryParse(vacation.VacationId, out vacationIdParsed))
            {
                return BadRequest();
            }

            Guid userIdParsed;
            if (!Guid.TryParse(vacation.UserId, out userIdParsed))
            {
                return BadRequest();
            }

            JoinVacationCommand command = new JoinVacationCommand(
                Guid.NewGuid(), 
                vacationIdParsed,
                userIdParsed,
                StatusJoining.Requested
            );

            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpPut("updateStatusJoining")]
        public IActionResult UpdateStatusJoining([FromBody] VacationJoiningDto vacation)
        {

            Guid vacationIdParsed;
            if (!Guid.TryParse(vacation.VacationId, out vacationIdParsed))
            {
                return BadRequest();
            }

            Guid userIdParsed;
            if (!Guid.TryParse(vacation.UserId, out userIdParsed))
            {
                return BadRequest();
            }

            GetJoiningByVacationIdAndUserIdQuery query = new GetJoiningByVacationIdAndUserIdQuery(vacationIdParsed, userIdParsed);
            VacationJoiningDto vacationJoiningDto = _dispatcher.Dispatch(query);

            Guid entityIdParsed;
            if (!Guid.TryParse(vacationJoiningDto.EntityId, out entityIdParsed))
            {
                return BadRequest();
            }

            UpdateStatusJoinVacationCommand command= new UpdateStatusJoinVacationCommand(
                entityIdParsed,
                vacationIdParsed,
                userIdParsed,
                vacation.StatusJoining
            );

            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpGet("userId/{userId}/joinings")]
        public IActionResult GetAllVacationJoiningsByUserId(string userId)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(userId, out entityIdParsed))
            {
                return BadRequest();
            }

            GetAllJoiningsByUserIdQuery query = new GetAllJoiningsByUserIdQuery(entityIdParsed);
            IList<VacationJoiningDto> vacationJoinings = _dispatcher.Dispatch(query);

            if (vacationJoinings == null)
            {
                return BadRequest(ResponseMessage.VacationNotFound);
            }

            return Ok(vacationJoinings);
        }

        [HttpGet("vacationId/{vacationId}/joinings")]
        public IActionResult GetAllVacationJoiningsByVacationId(string vacationId)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(vacationId, out entityIdParsed))
            {
                return BadRequest();
            }

            GetAllJoiningsByVacationIdQuery query = new GetAllJoiningsByVacationIdQuery(entityIdParsed);
            IList<VacationJoiningDto> vacationJoinings = _dispatcher.Dispatch(query);

            if (vacationJoinings == null)
            {
                return BadRequest(ResponseMessage.VacationNotFound);
            }

            return Ok(vacationJoinings);
        }

        [HttpGet("{vacationId}/{userId}/joinings")]
        public IActionResult GetAllVacationJoiningsByVacationId(string vacationId, string userId)
        {
            Guid vacationIdParsed;
            if (!Guid.TryParse(vacationId, out vacationIdParsed))
            {
                return BadRequest();
            }

            Guid userIdParsed;
            if (!Guid.TryParse(userId, out userIdParsed))
            {
                return BadRequest();
            }

            GetJoiningByVacationIdAndUserIdQuery query = new GetJoiningByVacationIdAndUserIdQuery(vacationIdParsed, userIdParsed);
            VacationJoiningDto vacationJoinings = _dispatcher.Dispatch(query);

            if (vacationJoinings == null)
            {
                return BadRequest(ResponseMessage.VacationNotFound);
            }

            return Ok(vacationJoinings);
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

        [HttpGet("entityId/{entityId}")]
        public IActionResult GetVacationByEntityId(string entityId)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(entityId, out entityIdParsed))
            {
                return BadRequest();
            }

            GetVacationByEntityIdQuery query = new GetVacationByEntityIdQuery(entityIdParsed);
            VacationDto vacation = _dispatcher.Dispatch(query);

            if (vacation == null)
            {
                return BadRequest(ResponseMessage.VacationNotFound);
            }

            GetLocationsByVacationIdQuery locationQuery = new GetLocationsByVacationIdQuery(entityIdParsed);
            vacation.VacationPoints = _dispatcher.Dispatch(locationQuery);

            return Ok(vacation);
        }
    }
}
