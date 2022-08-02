using FG.Database.MSSql.context;
using FG.Database.MSSql.Repositories;
using FG.Domain.DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MSSql.Repositories
{
    public class OpportunityRepository:GenericRepository<Opportunity>,IOpportunityRepository
    {
        public OpportunityRepository(FGDbContext context):base(context)
        {

        }
    }
}
