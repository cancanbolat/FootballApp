using Football.Application.Features.Commands.Players;
using Football.Core.Application.Features.Queries.Team;
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
    public class TeamController : ControllerBase
    {
        private readonly IMediator mediator;

        public TeamController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTeams()
        {
            var query = new GetAllTeamQuery();
            return Ok(await mediator.Send(query));
        }
    }
}
