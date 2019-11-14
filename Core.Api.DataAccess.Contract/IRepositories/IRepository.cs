using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.DataAccess.Contract.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Exist(int id);
        Task<bool> Exist(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get(T entity);
        Task Delete(int id);
        Task Delete(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Update(T entity);
        Task<T> Add(T entity);
    }
}
