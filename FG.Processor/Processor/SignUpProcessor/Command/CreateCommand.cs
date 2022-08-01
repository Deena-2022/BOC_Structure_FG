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

namespace FG.Processor.Processor.SignUpProcessor.Command
{
    public class CreateCommand:IRequest<string>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Companyname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Passwordagain { get; set; }

        public string Timezone { get; set; }

        public string Streetaddress_1 { get; set; }

        public string Streetaddress_2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
        public class CreateCommandHandler : IRequestHandler<CreateCommand, string>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;

            public CreateCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }
            public async Task<string> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                var result = mapper.Map<User>(request);
                await unitOfWork.user.Add(result);
                await unitOfWork.Save();
                return "Update Successfully";
            }
        }

       
    }
}
