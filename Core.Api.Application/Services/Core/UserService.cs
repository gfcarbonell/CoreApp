using AutoMapper;
using Core.Api.Application.Contract.IServices;
using Core.Api.Business.Core;
using Core.Api.Business.Core.StoreProcedures;
using Core.Api.DataAccess.Contract.Entities.Core;
using Core.Api.DataAccess.Contract.Entities.StoreProcedures;
using Core.Api.DataAccess.Contract.IRepositories.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Application.Services.Core
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<User> Add(User element)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User element)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Get(User element)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(sp_login element)
        {
            var map = _mapper.Map<sp_loginEntity>(element);
            var entity = await _userRepository.Login(map);
            return _mapper.Map<User>(entity);
        }

        public Task<User> Update(int id, User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User element)
        {
            throw new NotImplementedException();
        }
    }
}
