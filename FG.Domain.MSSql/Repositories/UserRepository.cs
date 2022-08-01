using FG.Database.MSSql.context;
using FG.Database.MSSql.Repositories;
using FG.Domain.DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MSSql.Repositories
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(FGDbContext context) : base(context)
        {

        }
        
    }
}
