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
    public class SystemService : ISystemService
    {
        private readonly ISystemRepository _systemRepository;
        private readonly IMapper _mapper;

        public SystemService(
            ISystemRepository systemRepository,
            IMapper mapper)
        {
            _systemRepository = systemRepository;
            _mapper = mapper;
        }

        public Task<Business.Core.System> Add(Business.Core.System element)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Business.Core.System element)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(Business.Core.System element)
        {
            throw new NotImplementedException();
        }

        public Task<Business.Core.System> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Business.Core.System>> Get(Business.Core.System element)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Business.Core.System>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Business.Core.System>> GetByUser(int UserID)
        {
            var entity = await _systemRepository.GetByUser(UserID);
            return _mapper.Map<IEnumerable<Business.Core.System>>(entity);
        }

        public Task<Business.Core.System> Update(int id, Business.Core.System element)
        {
            throw new NotImplementedException();
        }

        public Task<Business.Core.System> Update(Business.Core.System element)
        {
            throw new NotImplementedException();
        }
    }
}
