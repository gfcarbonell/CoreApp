using Core.Api.DataAccess.Contract.Entities.Core;
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

namespace Core.Api.DataAccess.Repositories.Core
{
    public class UserSessionRepository : IUserSessionRepository
    {
        private readonly ICoreDbContext _coreDbContext;

        public UserSessionRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }

        public async Task<UserSessionEntity> Add(UserSessionEntity entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_coreDbContext.Database.GetDbConnection().ConnectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@UserID", entity.UserID);
                    parameters.Add("@Token", entity.Token);
                    parameters.Add("@NotBeforeDate", entity.NotBeforeDate);
                    parameters.Add("@ExpiresDate", entity.ExpiresDate);
                    parameters.Add("@LoginDate", entity.LoginDate);
                    parameters.Add("@LogoutDate", entity.LogoutDate);
                    parameters.Add("@StateID", entity.StateID);

                    parameters.Add("@IsActive", entity.IsActive);
                    parameters.Add("@IsVisible", entity.IsVisible);
                    parameters.Add("@IsDelete", entity.IsDelete);
                    parameters.Add("@ChangeType", entity.ChangeType);
                    parameters.Add("@HostnameCreated", entity.HostnameCreated);
                    parameters.Add("@IPAddressCreated", entity.IPAddressCreated);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
                    parameters.Add("@CreateDate", entity.CreateDate);
                    parameters.Add("@HostnameUpdated", entity.HostnameUpdated);
                    parameters.Add("@IPAddressUpdated", entity.IPAddressUpdated);
                    parameters.Add("@UpdatedBy", entity.UpdatedBy);
                    parameters.Add("@UpdateDate", entity.UpdateDate);

                    parameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
                    parameters.Add("@Code", dbType: DbType.Int64, direction: ParameterDirection.Output, size: 5215585);
                    parameters.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                    parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);

                    string query = "[dbo].[usp_ins_user_sessions]";

                    await connection.OpenAsync();

                    var result = await connection.ExecuteAsync(sql: query,
                                                         param: parameters,
                                                         commandType: CommandType.StoredProcedure);

                    var ErrorMessage = parameters.Get<string>("@ErrorMessage");
                    var ErrorCode = parameters.Get<int>("@ErrorCode");

                    if (ErrorCode < 0 || !string.IsNullOrEmpty(ErrorMessage))
                    {
                        throw new Exception(ErrorMessage);
                    }

                    entity.ID = parameters.Get<int>("@ID");
                    entity.Code = parameters.Get<long>("@Code");
                    return entity;
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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UserSessionEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(UserSessionEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserSessionEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSessionEntity>> Get(UserSessionEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSessionEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserSessionEntity> Update(int id, UserSessionEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserSessionEntity> Update(UserSessionEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
