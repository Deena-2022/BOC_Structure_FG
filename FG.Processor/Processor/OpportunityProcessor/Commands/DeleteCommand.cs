using AutoMapper;
using FG.Database.MSSql.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FG.Processor.Processor.OpportunityProcessor.Commands
{
    public class DeleteCommand:IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, int>
        {
            private readonly IUnitOfWork unitOfWork;

            public DeleteCommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
                
            }
            public async Task<int> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.Opportunity.Delete(request.Id);
                await unitOfWork.Save();
                return request.Id;
                
            }
        }
    }
}
