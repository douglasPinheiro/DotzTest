using AutoMapper;
using TesteTecnico.Application.ViewModels.Address;
using TesteTecnico.Application.ViewModels.Company;
using TesteTecnico.Application.ViewModels.Product;
using TesteTecnico.Application.ViewModels.User;
using TesteTecnico.Application.ViewModels.Wallet;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, SignupViewModel>().ForMember(d => d.Password, opt => opt.Ignore());
            CreateMap<Address, CreateOrEditAddressViewModel>();
            CreateMap<Transaction, ExtractItemViewModel>()
                .ForMember(d => d.Company, opt => opt.Ignore())
                .ForMember(d => d.Product, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Company = new CompanyItemViewModel
                    {
                        CNPJ = src.Company.CNPJ,
                        Id = src.Company.Id,
                        Name = src.Company.Name
                    };

                    dest.Product = new ProductItemViewModel
                    {
                        Id = src.Product.Id,
                        Name = src.Product.Name
                    };
                });
        }
    }
}
