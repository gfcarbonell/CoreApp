using AutoMapper;
using Core.Api.Application.Contract.IServices.Core;
using Core.Api.Business.Core;
using Core.Api.DataAccess.Contract.Entities.Core;
using Core.Api.DataAccess.Contract.IRepositories.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Application.Services.Core
{
    public class UserSessionService: IUserSessionService
    {
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IMapper _mapper;

        public UserSessionService(
            IUserSessionRepository userSessionRepository,
            IMapper mapper)
        {
            _userSessionRepository = userSessionRepository;
            _mapper = mapper;
        }

        public async Task<UserSession> Add(UserSession element)
        {
            var map = _mapper.Map<UserSessionEntity>(element);
            var entity = await _userSessionRepository.Add(map);
            return _mapper.Map<UserSession>(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UserSession element)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(UserSession element)
        {
            throw new NotImplementedException();
        }

        public Task<UserSession> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSession>> Get(UserSession element)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSession>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserSession> Update(int id, UserSession element)
        {
            throw new NotImplementedException();
        }

        public Task<UserSession> Update(UserSession element)
        {
            throw new NotImplementedException();
        }
    }
}
