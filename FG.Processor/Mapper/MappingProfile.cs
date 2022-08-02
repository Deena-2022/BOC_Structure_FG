using AutoMapper;
using FG.Domain.DataEntity;
using FG.Domain.DTO_s;
using FG.Processor.Processor.LeadsProcessor.Commands;
using FG.Processor.Processor.SignUpProcessor.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace FG.Domain.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lead, LeadDto>();
            CreateMap<UpdateCommand, Lead>();
            CreateMap<CreateCommand, User>();
            CreateMap<Opportunity, OpportunityDto>();
        }
    }
}
