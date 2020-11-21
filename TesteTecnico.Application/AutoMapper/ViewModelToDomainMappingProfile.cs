using AutoMapper;
using TesteTecnico.Application.ViewModels.User;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            MapUser();
        }

        private void MapUser()
        {
            CreateMap<SignupViewModel, User>()
                .ForMember(d => d.NormalizedUserName, opt => opt.Ignore())
                .ForMember(d => d.NormalizedEmail, opt => opt.Ignore())
                .ForMember(d => d.EmailConfirmed, opt => opt.Ignore())
                .ForMember(d => d.PasswordHash, opt => opt.Ignore())
                .ForMember(d => d.SecurityStamp, opt => opt.Ignore())
                .ForMember(d => d.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(e => e.Mobile))
                .ForMember(d => d.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(d => d.LockoutEnd, opt => opt.Ignore())
                .ForMember(d => d.LockoutEnabled, opt => opt.Ignore())
                .ForMember(d => d.AccessFailedCount, opt => opt.Ignore())
                .ForMember(d => d.UserName, opt => opt.MapFrom(e => e.Email))
                .ForMember(d => d.PhoneNumberConfirmed, opt => opt.Ignore());
        }
    }
}
