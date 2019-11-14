using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Application.Contract.IServices
{
    public interface IService<T> where T : class
    {
        Task<bool> Exist(int id);
        Task<bool> Exist(T element);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get(T element);
        Task Delete(int id);
        Task Delete(T element);
        Task<T> Update(int id, T element);
        Task<T> Update(T element);
        Task<T> Add(T element);
    }
}
