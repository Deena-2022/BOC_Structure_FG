using FG.Database.MSSql.context;
using FG.Database.MSSql.Repositories;
using FG.Processor.Processor.SignUpProcessor.Command;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fg.FluentValidation
{
    public class CreateUserValidator:AbstractValidator<CreateCommand>
    {
        private readonly FGDbContext context;

        public CreateUserValidator(FGDbContext context)
        {
            RuleFor(x => x.Firstname).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Lastname).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Companyname).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Phone).NotNull().NotEmpty().Matches("^[0-9 ]*$").MaximumLength(10);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().
                WithMessage("Invalid email format.").Must(UniqueMail).WithMessage("Email already exists.");       
            RuleFor(x => x.Password).NotNull().NotEmpty().Matches("((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|" +
            "(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$");
            RuleFor(x => x.Passwordagain).NotNull().NotEmpty().Equal(x => x.Password).WithMessage("Passwords does not match"); ;
            RuleFor(x => x.Timezone).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Streetaddress_1).NotNull().NotEmpty();
            RuleFor(x => x.Streetaddress_2).NotNull().NotEmpty();
            RuleFor(x => x.City).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.State).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Zip).NotNull().NotEmpty().Matches("^([0-9]{3} [0-9]{3})$");
            this.context = context;
        }

        private bool UniqueMail(string email)
        {          
            var result = context.tbl_User.Where(x => x.Email == email);
            if (result == null) return true;
            return false;
        }
    }
}
