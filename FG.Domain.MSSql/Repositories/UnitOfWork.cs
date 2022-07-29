using FG.Database.MSSql.context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FG.Database.MSSql.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FGDbContext context;
        public ILeadRepository LeadRepository { get; }

        public UnitOfWork(FGDbContext context,ILeadRepository leadRepository)
        {
            this.context = context;
            LeadRepository = leadRepository;
        }
        public ILeadRepository lead => new LeadRepository(context);

        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
