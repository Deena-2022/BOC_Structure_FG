using AutoMapper;
using FG.Domain.DataEntity;
using FG.Domain.DTO_s;
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
        }
    }
}
