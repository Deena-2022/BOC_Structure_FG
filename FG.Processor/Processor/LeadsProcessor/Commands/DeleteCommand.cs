using AutoMapper;
using FG.Database.MSSql.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FG.Processor.Processor.LeadsProcessor.Commands
{
    public class DeleteCommand:IRequest<int>
    {
        public int Lid { get; set; }
        public class DeleteCommandHAandler : IRequestHandler<DeleteCommand, int>
        {
            private readonly IUnitOfWork unitOfWork;

            public DeleteCommandHAandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
               
            }
            public async Task<int> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.lead.Delete(request.Lid);
                await unitOfWork.Save();
                return request.Lid;
            }
        }
    }
}
