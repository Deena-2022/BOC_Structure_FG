using FG.Domain.Processor.LeadsPage.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opportunity_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OppotunityController : ControllerBase
    {
        private readonly IMediator mediator;

        public OppotunityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllQuery()));
        }
    }
}
