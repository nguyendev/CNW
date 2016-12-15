using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Infrastructure
{
    public interface IGenericRepository<T>
    {
        Task<T> Get(int? id);
        bool Exists(int id);
        Task<List<T>> GetAll();
        Task Add(T Entity);
        Task Update(T Entity);

        Task Delete(int id);
    }
}
