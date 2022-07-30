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
            private readonly IMapper mapper;

            public DeleteCommandHAandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }
            public async Task<int> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var result =  unitOfWork.lead.Delete(request.Lid);
                await unitOfWork.Save();
                return request.Lid;
            }
        }
    }
}
