using FG.Database.MSSql.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FG.Database.MSSql.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FGDbContext context;
        private readonly DbSet<T> table;

        public GenericRepository(FGDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task Delete(int Entity)
        {
            T exists =await table.FindAsync(Entity);
            table.Remove(exists);
        }

        public Task<List<T>> GetAll()
        {
            return context.Set<T>().ToListAsync();
        }

        public Task<T> GetbyId(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
