using Core.Api.DataAccess.Contract.Entities.Core;
using Core.Api.DataAccess.Contract.Entities.StoreProcedures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.DataAccess.Contract.IRepositories.Core
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> Login(sp_loginEntity element);
    }
}
