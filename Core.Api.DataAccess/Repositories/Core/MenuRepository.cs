using Core.Api.DataAccess.Contract.Entities.Core;
using Core.Api.DataAccess.Contract.IRepositories.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.DataAccess.Repositories.Core
{
    public class MenuRepository : IMenuRepository
    {
        public Task<MenuEntity> Add(MenuEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(MenuEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(MenuEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<MenuEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuEntity>> Get(MenuEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MenuEntity> Update(int id, MenuEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<MenuEntity> Update(MenuEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
