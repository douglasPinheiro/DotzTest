using AutoMapper;
using TesteTecnico.Application.ViewModels.User;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, SignupViewModel>().ForMember(d => d.Password, opt => opt.Ignore());
        }
    }
}
