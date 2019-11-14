using Core.Api.DataAccess.Contract.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.DataAccess.Contract.IRepositories.Core
{
    public interface ISystemRepository : IRepository<SystemEntity>
    {
        Task<IEnumerable<SystemEntity>> GetByUser(int UserID);
    }
}
