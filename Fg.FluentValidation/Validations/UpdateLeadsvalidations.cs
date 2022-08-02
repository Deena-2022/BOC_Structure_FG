using FG.Processor.Processor.LeadsProcessor.Commands;
using FluentValidation;
using System;

namespace Fg.FluentValidation
{
    public class UpdateLeadsvalidations:AbstractValidator<UpdateCommand>
    {
        public UpdateLeadsvalidations()
        {
            RuleFor(x => x.Lname).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LProject_Name).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LStatus).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LAdded).NotNull().NotEmpty();
            RuleFor(x => x.LType).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LContact).NotNull().NotEmpty().Matches("^[0-9 ]*$");
            RuleFor(x => x.LAction).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LAssignee).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LBid_Date).NotNull().NotEmpty();
        }

       
    }
}
