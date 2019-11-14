using Core.Api.DataAccess.Contract.Entities.Core;
using Core.Api.DataAccess.Contract.Entities.StoreProcedures;
using Core.Api.DataAccess.Contract.IDbContexts;
using Core.Api.DataAccess.Contract.IRepositories.Core;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Api.DataAccess.Repositories.Core
{
    public class UserRepository : IUserRepository
    {
        private readonly ICoreDbContext _coreDbContext;

        public UserRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }

        public Task<UserEntity> Add(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> Get(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> Login(sp_loginEntity entity)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_coreDbContext.Database.GetDbConnection().ConnectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Username", entity.Username);
                    parameters.Add("@Password", entity.Password);
                    parameters.Add("@IPAddress", entity.IPAddress);
                    parameters.Add("@Hostname ", entity.Hostname);
                    parameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
                    parameters.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                    parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);

                    string query = "[dbo].[usp_login]";

                    await connection.OpenAsync();

                    var result = await connection.ExecuteAsync(sql: query,
                                                         param: parameters,
                                                         commandType: CommandType.StoredProcedure);

                    var ErrorMessage = parameters.Get<string>("@ErrorMessage");
                    int ErrorCode = parameters.Get<int>("@ErrorCode");

                    if (ErrorCode < 0 || !string.IsNullOrEmpty(ErrorMessage))
                    {
                        throw new Exception(ErrorMessage);
                    }
                    var ID = parameters.Get<int>("@ID");
                    var Username = entity.Username;
                    return new UserEntity()
                    {
                        ID = ID,
                        Username = Username,
                        Nickname = null,
                    };
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

        public Task<UserEntity> Update(int id, UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
