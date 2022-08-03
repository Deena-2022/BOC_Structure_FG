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

namespace FG.Processor.Processor.OpportunityProcessor.Commands
{
    public class UpdateOpportunity : IRequest<int>
    {
        public string Customer { get; set; }

        public string Created { get; set; }

        public string Modified { get; set; }

        public string Status { get; set; }

        public string Name_Number { get; set; }

        public string Address { get; set; }

        public string Salesperson { get; set; }

        public string Action { get; set; }

        public string Due_Date { get; set; }

        public int Id { get; set; }
        public class UpdateOpportunityHandler : IRequestHandler<UpdateOpportunity, int>
        {
            private readonly IUnitOfWork unitOfWork;

            private readonly IMapper mapper;

            public UpdateOpportunityHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;

            }
            public async Task<int> Handle(UpdateOpportunity request, CancellationToken cancellationToken)
            {
                unitOfWork.Opportunity.Update(mapper.Map<Opportunity>(request));
                await unitOfWork.Save();
                return request.Id;
            }
        }


    }
}
