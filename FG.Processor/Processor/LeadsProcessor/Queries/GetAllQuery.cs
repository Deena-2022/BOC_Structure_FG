using AutoMapper;
using FG.Database.MSSql.Repositories;
using FG.Domain.DTO_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FG.Domain.Processor.LeadsPage.Queries
{
    public class GetAllQuery : IRequest<List<LeadDto>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<LeadDto>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;

            public GetAllQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }

            public async  Task<List<LeadDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                var leads =await unitOfWork.lead.GetAll();
                var result = mapper.Map<List<LeadDto>>(leads);
                return new List<LeadDto>(result);
            }
        }
    }
}
