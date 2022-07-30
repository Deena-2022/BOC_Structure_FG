using AutoMapper;
using FG.Database.MSSql.Repositories;
using FG.Domain.DataEntity;
using FG.Domain.DTO_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FG.Processor.Processor.LeadsProcessor.Commands
{
    public class UpdateCommand:IRequest<int>
    {
        public string Lname { get; set; }

        public string LProject_Name { get; set; }

        public string LStatus { get; set; }

        public string LAdded { get; set; }

        public string LType { get; set; }

        public string LContact { get; set; }

        public string LAction { get; set; }

        public string LAssignee { get; set; }

        public string LBid_Date { get; set; }

        public int Lid { get; set; }

        public class UpdateCommandHandler : IRequestHandler<UpdateCommand, int>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;

            public UpdateCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }
            public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                unitOfWork.lead.Update(mapper.Map<Lead>(request));
                await unitOfWork.Save();
                return request.Lid;
            }
        }
    }
}
