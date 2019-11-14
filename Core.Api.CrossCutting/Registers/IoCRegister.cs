using Core.Api.Application.Contract.IServices;
using Core.Api.Application.Contract.IServices.Core;
using Core.Api.Application.Services.Core;
using Core.Api.DataAccess.Contract.IRepositories.Core;
using Core.Api.DataAccess.Repositories.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.CrossCutting.Registers
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterOthers(services);
            return services;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserSessionService, UserSessionService>();
            services.AddTransient<ISystemService, SystemService>();

            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserSessionRepository, UserSessionRepository>();
            services.AddTransient<ISystemRepository, SystemRepository>();
            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            return services;
        }
    }
}
