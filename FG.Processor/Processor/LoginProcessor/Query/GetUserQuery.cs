using FG.Database.MSSql.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FG.Processor.Processor.LoginProcessor.Query
{
    public class GetUserQuery:IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class GetUserHandler : IRequestHandler<GetUserQuery, string>
        {
            private readonly IUnitOfWork unitOfWork;

            public GetUserHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<string> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var result =  unitOfWork.user.FindByCondition(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();
                await unitOfWork.Save();
                if (result == null) return "Login Failed.....!";
                return "Login Successfully....!";
            }
        }
    }
}
