using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace HometaskEntity.DAL.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(int id, T item);
        Task Delete(int id);
    }
}
