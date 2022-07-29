using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FG.Database.MSSql.Repositories
{
    public interface IUnitOfWork
    {
        ILeadRepository lead { get; }
        Task Save();
    }
}
