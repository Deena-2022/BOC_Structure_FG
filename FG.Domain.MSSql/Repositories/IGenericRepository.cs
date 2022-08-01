using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FG.Database.MSSql.Repositories
{
    public interface IGenericRepository<T> where T:class
    {
        Task<List<T>> GetAll();
        Task<T> GetbyId(int entity);
        void Update(T Entity);
        Task Add(T entity);
        Task Delete(int Entity);
    }
}
