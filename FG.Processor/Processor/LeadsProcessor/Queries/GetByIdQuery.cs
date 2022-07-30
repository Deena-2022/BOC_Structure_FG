using AutoMapper;
using FG.Database.MSSql.Repositories;
using FG.Domain.DTO_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FG.Processor.Processor.LeadsPage.Queries
{
    public class GetByIdQuery:IRequest<LeadDto>
    {
        public int Lid { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, LeadDto>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;

            public GetByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }
            public async Task<LeadDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var leads =await unitOfWork.lead.GetbyId(request.Lid);
                var result = mapper.Map<LeadDto>(leads);
                if (result == null)
                {
                    return null;
                }
                return result;
               }
        }
    }
}
