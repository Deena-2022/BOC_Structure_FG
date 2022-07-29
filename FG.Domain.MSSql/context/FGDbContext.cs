using FG.Domain.DataEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FG.Database.MSSql.context
{
    public class FGDbContext : DbContext
    {
        public FGDbContext(DbContextOptions<FGDbContext>options):base(options)
        {

        }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<User> tbl_User { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
    }
}
