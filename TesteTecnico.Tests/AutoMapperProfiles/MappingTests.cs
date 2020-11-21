using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteTecnico.Application.AutoMapper;

namespace TesteTecnico.Tests.AutoMapperProfiles
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void AutoMapper_ConfigurationModelToViewModel_IsValid()
        {
            var configuration = new MapperConfiguration(opt
                => opt.AddProfile<DomainToViewModelMappingProfile>());

            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AutoMapper_ConfigurationViewModelToEntity_IsValid()
        {
            var configuration = new MapperConfiguration(opt
                => opt.AddProfile<ViewModelToDomainMappingProfile>());

            configuration.AssertConfigurationIsValid();
        }
    }
}
