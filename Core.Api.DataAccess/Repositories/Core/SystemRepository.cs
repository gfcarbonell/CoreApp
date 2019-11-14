using Core.Api.DataAccess.Contract.Entities.Core;
using Core.Api.DataAccess.Contract.IDbContexts;
using Core.Api.DataAccess.Contract.IRepositories.Core;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.DataAccess.Repositories.Core
{
    public class SystemRepository : ISystemRepository
    {
        private readonly ICoreDbContext _coreDbContext;

        public SystemRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }


        public Task<SystemEntity> Add(SystemEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(SystemEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(SystemEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<SystemEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SystemEntity>> GetByUser(int UserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_coreDbContext.Database.GetDbConnection().ConnectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@UserId", UserID);
                    string query = "[dbo].[usp_sel_system_module_menu]";

                    await connection.OpenAsync();

                    using (SqlMapper.GridReader _result_QueryMultipleAsync = await connection.QueryMultipleAsync(sql: query, param: parameters, commandType: CommandType.StoredProcedure))
                    {
                        var systems = (await _result_QueryMultipleAsync.ReadAsync<SystemEntity>()).ToList(); 
                        var modules = (await _result_QueryMultipleAsync.ReadAsync<ModuleEntity>()).ToList();
                        var menus = (await _result_QueryMultipleAsync.ReadAsync<MenuEntity>()).ToList();

                        if (systems != null)
                        {
                            foreach (var module in modules)
                            {
                                module.Menus = new List<MenuEntity>();
                                foreach (var menu in menus)
                                {
                                    if(module.ID == menu.ModuleID)
                                    {
                                        module.Menus.Add(menu);
                                    }
                                }
                            }

                            foreach (var system in systems)
                            {
                                system.Modules = new List<ModuleEntity>();
                                foreach (var module in modules)
                                {
                                    if (system.ID == module.SystemID)
                                    {
                                        system.Modules.Add(module);
                                    }
                                }
                            }
                        }
                        return systems;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Task<IEnumerable<SystemEntity>> Get(SystemEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SystemEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SystemEntity> Update(int id, SystemEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<SystemEntity> Update(SystemEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
