
using FG.Processor.Processor.OpportunityProcessor.Commands;
using FG.Processor.Processor.OpportunityProcessor.Query;
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
    public class OpportunityController : ControllerBase
    {
        private readonly IMediator mediator;

        public OpportunityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllQuery()));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await mediator.Send(new GetByIdQuery { Id =Id }));
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id,UpdateOpportunity command)
        {
            if (Id != command.Id) 
            { 
                return BadRequest(); 
            }
            return Ok(await mediator.Send(command));
        }
        [HttpDelete("{Id}")]
        public  async Task<IActionResult> Delete(int Id)
        {
            return Ok(await mediator.Send(new DeleteCommand { Id = Id}));
        }
    }
}
