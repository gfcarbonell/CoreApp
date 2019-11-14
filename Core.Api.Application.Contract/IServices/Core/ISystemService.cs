using Core.Api.Business.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Application.Contract.IServices.Core
{
    public interface ISystemService : IService<Business.Core.System>
    {
        Task<IEnumerable<Business.Core.System>> GetByUser(int UserID);
    }
}
