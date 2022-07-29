using FG.Domain.DTO_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FG.Domain.Processor.LeadsPage.Queries
{
    public class GetAllQuery : IRequest<IEnumerable<LeadDto>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<LeadDto>>
        {
            public GetAllQueryHandler(IUnitOfWork unitOfWork)
            {

            }

            public Task<IEnumerable<LeadDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
