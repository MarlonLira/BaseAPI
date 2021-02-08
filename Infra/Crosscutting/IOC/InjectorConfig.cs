using Application.Interfaces;
using Application.Mapper;
using Application.Services;
using Domain.Interfaces;
using Infra.Data.Repositories;
using Unity;

namespace Infra
{
    public static class InjectorConfig
    {
        public static UnityContainer GetContainer()
        {
            var container = new UnityContainer();

            container.RegisterInstance(AutoMapperConfig.mapper);

            //services
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserAffiliationService, UserAffiliationService>();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IPartnerService, PartnerService>();
            container.RegisterType<ILogService, LogService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<ICollaboratorService, CollaboratorService>();

            //repositories
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserAffiliationRepository, UserAffiliationRepository>();
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<IPartnerRepository, PartnerRepository>();
            container.RegisterType<IPartnerRepository, PartnerRepository>();
            container.RegisterType<ILogRepository, LogRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<ICollaboratorRepository, CollaboratorRepository>();

            return container;
        }
    }
}