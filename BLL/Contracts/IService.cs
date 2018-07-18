using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace HometaskEntity.BLL.Contracts
{
    public interface IService<T> where T: class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T t);
        Task Update(int id, T t);
        Task Delete(int id);
    }
}