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

        public GenericRepository(FGDbContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int Entity)
        {
            T exist =await context.Set<T>().FindAsync(Entity);
            context.Remove(exist);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
         
        public async Task<T> GetbyId(int entity)
        {
            return await context.Set<T>().FindAsync(entity);
        }

        public void Update(T Entity)
        {
            context.Entry(Entity).State = EntityState.Modified;
        }
    }
}
