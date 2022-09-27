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

namespace FG.Processor.Processor.OpportunityProcessor.Query
{
    public class GetByIdQuery : IRequest<OpportunityDto>
    {
        public int Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, OpportunityDto>
        {
            private readonly IMapper mapper;
            private readonly IUnitOfWork unitOfWork;
            public GetByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }
            public async Task<OpportunityDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var opp = await unitOfWork.Opportunity.GetbyId(request.Id);
                var result = mapper.Map<OpportunityDto>(opp);
                if (result == null)
                {
                    return null;
                }                   
                return result;
            }
        }

    }
}
