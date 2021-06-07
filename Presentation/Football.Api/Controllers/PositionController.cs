using Football.Core.Application.Features.Queries.Position;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IMediator mediator;

        public PositionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPositions()
        {
            var query = new GetAllPositionQuery();
            return Ok(await mediator.Send(query));
        }
    }
}
