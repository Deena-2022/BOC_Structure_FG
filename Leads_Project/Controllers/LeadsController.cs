
using FG.Domain.Processor.LeadsPage.Queries;
using FG.Processor.Processor.LeadsPage.Queries;
using FG.Processor.Processor.LeadsProcessor.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly IMediator mediator;


        public LeadsController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllQuery()));
        }

        [HttpGet("{Lid}")]
        public async Task<IActionResult> GetById(int Lid)
        {
            return Ok(await mediator.Send(new GetByIdQuery { Lid = Lid }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Lid, UpdateCommand command)
        {
            if (Lid != command.Lid)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{Lid}")]
        public async Task<IActionResult>Delete(int Lid)
        {
            return Ok(await mediator.Send(new DeleteCommand { Lid = Lid }));
        }
    }
}
