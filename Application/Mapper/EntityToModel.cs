using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.Password, opt => opt.Ignore());

            CreateMap<Collaborator, CollaboratorViewModel>()
                .ForMember(x => x.Password, opt => opt.Ignore());

            CreateMap<Client, ClientViewModel>();
            CreateMap<UserAffiliation, UserAffiliationViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<PartnerAddress, PartnerAddressViewModel>();
            CreateMap<Partner, PartnerViewModel>();
            CreateMap<Rule, RuleViewModel>();

        }
    }
}
