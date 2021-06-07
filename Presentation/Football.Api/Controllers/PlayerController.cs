using Football.Application.Features.Commands.Players;
using Football.Core.Application.Features.Commands.Players;
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
    [Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlayerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPlayerQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailed(Guid id)
        {
            var query = new GetPlayerDetailQuery() { Id = id };
            return Ok(await mediator.Send(query));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePlayer(CreatePlayerCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
