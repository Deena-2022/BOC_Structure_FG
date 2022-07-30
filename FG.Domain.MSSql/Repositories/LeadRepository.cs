using FG.Database.MSSql.context;
using FG.Domain.DataEntity;
using FG.Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace FG.Database.MSSql.Repositories
{
    public class LeadRepository:GenericRepository<Lead>, ILeadRepository
    {
        public LeadRepository(FGDbContext context):base(context)
        {

        }
    }
}
