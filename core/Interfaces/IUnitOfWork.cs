using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisRepository Paises { get; }
        Task<int> SaveAsync();
    }
}