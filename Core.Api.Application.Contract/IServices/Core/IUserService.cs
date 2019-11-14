using Core.Api.Business.Core;
using Core.Api.Business.Core.StoreProcedures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Application.Contract.IServices
{
    public interface IUserService: IService<User>
    {
        Task<User> Login(sp_login element);        
    }
}
