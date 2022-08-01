using Database.MSSql.Repositories;
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
        public IUserRepository UserRepository { get; }

        public UnitOfWork(FGDbContext context,ILeadRepository leadRepository,IUserRepository userRepository)
        {
            this.context = context;
            LeadRepository = leadRepository;
            UserRepository = userRepository;
        }
        public ILeadRepository lead => new LeadRepository(context);

        public IUserRepository user =>  new UserRepository(context);

        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
