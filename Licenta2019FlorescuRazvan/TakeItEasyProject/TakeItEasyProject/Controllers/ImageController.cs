using Microsoft.AspNetCore.Mvc;
using System;
using BusinessLogicReader.CqrsCore.Queries.Images;
using Models;
using BusinessLogicWriter.CqrsCore;

namespace TakeItEasyProject.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public ImageController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet("{entityId}")]
        public IActionResult GetImageByEntityId(string entityId)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(entityId, out entityIdParsed))
            {
                return BadRequest();
            }

            GetImageByEntityIdQuery query = new GetImageByEntityIdQuery(entityIdParsed);
            ImageDto  result = _dispatcher.Dispatch(query);

            return Ok(result);
        }

    }
}
