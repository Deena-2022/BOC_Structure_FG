using AutoMapper;
using FG.Database.MSSql.Repositories;
using FG.Domain.DTO_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FG.Processor.Processor.OpportunityProcessor.Query
{
    public class GetAllQuery:IRequest<List<OpportunityDto>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<OpportunityDto>>
        {
            private readonly IUnitOfWork unitofwork;
            private readonly IMapper mapper;

            public GetAllQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                unitofwork = unitOfWork;
                this.mapper = mapper;
            }

            

            public async Task<List<OpportunityDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                var opp = await unitofwork.Opportunity.GetAll();
                var result = mapper.Map<List<OpportunityDto>>(opp);
                return result;

            }
        }
    }
}
