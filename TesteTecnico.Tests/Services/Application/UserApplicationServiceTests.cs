using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using TesteTecnico.Application.Services;
using TesteTecnico.Application.ViewModels.Address;
using TesteTecnico.Application.ViewModels.User;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Tests.Services.Application
{
    [TestClass]
    public class UserApplicationServiceTests
    {
        [TestMethod]
        public async Task IShouldCanCreateAUser()
        {
            var userToCreate = new User
            {
                Id="asdf798asdfas-asjkdhrjkwer8",
                Email = "testando@gmail.com"
            };
            var viewModel = new SignupViewModel
            {
                Email = "testando@gmail.com"
            };
            var viewModelResult = new SignupViewModel
            {
                Email = "testando@gmail.com"
            };

            var mockForDomainService = new Mock<IUserService>();
            mockForDomainService.Setup(service => service.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(userToCreate)
                .Verifiable();

            var mockForMapper = new Mock<IMapper>();
            mockForMapper.Setup(m => m.Map<User>(It.IsAny<SignupViewModel>()))
                .Returns(userToCreate)
                .Verifiable();

            mockForMapper.Setup(m => m.Map<SignupViewModel>(It.IsAny<User>()))
                .Returns(viewModelResult)
                .Verifiable();

            var service = new UserApplicationService(mockForMapper.Object,
                mockForDomainService.Object);

            var result = await service.CreateUser(viewModel);

            Assert.AreEqual(viewModelResult, result);
            mockForDomainService.VerifyAll();
            mockForMapper.VerifyAll();
        }

        [TestMethod]
        public async Task IShouldCanCreateOrUpdateAUserAddress()
        {
            string email = "testando@gmail.com";
            var user = new User
            {
                Email = email,
                Id = "jkl34lk435-klj2342"
            };
            var viewModel = new CreateOrEditAddressViewModel
            {
                City = "SP"
            };
            var address = new Address
            {
                City = "SP"
            };

            var mockForDomainService = new Mock<IUserService>();
            mockForDomainService.Setup(service => service.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(user)
                .Verifiable();

            mockForDomainService.Setup(service => service.CreateOrEditAddress(It.IsAny<User>(), It.IsAny<Address>()))
                .Returns(user)
                .Verifiable();

            var mockForMapper = new Mock<IMapper>();
            mockForMapper.Setup(m => m.Map<Address>(It.IsAny<CreateOrEditAddressViewModel>()))
                .Returns(address)
                .Verifiable();

            mockForMapper.Setup(m => m.Map<CreateOrEditAddressViewModel>(It.IsAny<Address>()))
                .Returns(viewModel)
                .Verifiable();

            var service = new UserApplicationService(mockForMapper.Object,
                mockForDomainService.Object);

            var result = await service.CreateOrEditAddress(email, viewModel);

            Assert.AreEqual(viewModel, result);
            mockForDomainService.VerifyAll();
            mockForMapper.VerifyAll();
        }
    }
}
