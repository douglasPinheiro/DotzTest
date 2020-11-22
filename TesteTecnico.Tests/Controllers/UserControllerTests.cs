using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using TesteTecnico.Api.Controllers;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.ViewModels.User;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task IShouldCanCreateAUser()
        {
            // Prepare
            var userViewModel = new SignupViewModel
            {
                Email = "testando@gmail.com",
                Password = "somepassword"
            };
            var userResponse = new SignupViewModel
            {
                Email = "testando@gmail.com",
                Password = null
            };

            var mockForDomainUserService = new Mock<IUserService>();
            mockForDomainUserService.Setup(service => service.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(null as User)
                .Verifiable();

            var mockForApplicationUserService = new Mock<IUserApplicationService>();
            mockForApplicationUserService.Setup(service => service.CreateUser(userViewModel))
                .ReturnsAsync(userResponse)
                .Verifiable();

            var controller = new UserController(
                mockForDomainUserService.Object,
                mockForApplicationUserService.Object,
                null, null);

            // Action
            var result = await controller.Create(userViewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<SignupViewModel>));
            Assert.AreEqual(userResponse, result.Value);
            Assert.AreEqual(userResponse.Password, null);
            mockForDomainUserService.VerifyAll();
            mockForApplicationUserService.VerifyAll();
        }

        [TestMethod]
        public async Task IShouldReturnBadRequestIfTryCreateAUserWithExistentEmail()
        {
            var existentUser = new User
            {
                Id = "asdf-aewrwe-asdfa",
                Email = "testando@gmail.com"
            };
            var userViewModel = new SignupViewModel
            {
                Email = "testando@gmail.com",
                Password = "somepassword"
            };

            var mockForDomainUserService = new Mock<IUserService>();
            mockForDomainUserService.Setup(service => service.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(existentUser)
                .Verifiable();

            var controller = new UserController(
                mockForDomainUserService.Object,
                null, null, null);

            var result = await controller.Create(userViewModel);
            var resultData = result.Result as BadRequestObjectResult;

            Assert.IsNull(result.Value);
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
            Assert.AreEqual(resultData.StatusCode, 400);
            Assert.AreEqual(resultData.Value, "Email já cadastrado");
            mockForDomainUserService.VerifyAll();
        }

        [TestMethod]
        public async Task IShouldCanDoLoginAndReturnJWT()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1";
            var existentUser = new User
            {
                Id = "asdf-aewrwe-asdfa",
                Email = "testando@gmail.com",
                IsActive = true
            };
            var viewModel = new SigninViewModel
            {
                Email = "testando@gmail.com",
                Password = "somepassword"
            };

            var mockForDomainUserService = new Mock<IUserService>();
            mockForDomainUserService.Setup(service => service.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(existentUser)
                .Verifiable();

            mockForDomainUserService.Setup(service => service.DoLogin(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true)
                .Verifiable();

            var mockForJWTService = new Mock<IJwtTokenService>();
            mockForJWTService.Setup(service => service.GenerateToken(existentUser))
                .Returns(token)
                .Verifiable();

            var controller = new UserController(
                mockForDomainUserService.Object,
                null, null,
                mockForJWTService.Object);

            var result = await controller.Login(viewModel);
            var resultData = result as OkObjectResult;
            string tokenResult = resultData.Value?.GetType().GetProperty("token")?.GetValue(resultData.Value, null).ToString();

            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(resultData.StatusCode, 200);
            Assert.AreEqual(token, tokenResult);
            mockForDomainUserService.VerifyAll();
            mockForJWTService.VerifyAll();
        }

        [TestMethod]
        public async Task IShouldReturnBadRequestIfUserNotExistOnLogin()
        {
            var existentUser = new User
            {
                Id = "asdf-aewrwe-asdfa",
                Email = "testando@gmail.com",
                IsActive = true
            };
            var viewModel = new SigninViewModel
            {
                Email = "testando@gmail.com",
                Password = "somepassword"
            };

            var mockForDomainUserService = new Mock<IUserService>();
            mockForDomainUserService.Setup(service => service.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(null as User)
                .Verifiable();

            var controller = new UserController(
                mockForDomainUserService.Object,
                null, null, null);

            var result = await controller.Login(viewModel);
            var resultData = result as BadRequestObjectResult;
            string error = resultData.Value?.GetType().GetProperty("error_description")?.GetValue(resultData.Value, null).ToString();

            Assert.IsInstanceOfType(resultData, typeof(BadRequestObjectResult));
            Assert.AreEqual(resultData.StatusCode, 400);
            Assert.AreEqual(error, "Usuario não existe");
            mockForDomainUserService.VerifyAll();
        }

        [TestMethod]
        public async Task IShouldReturnBadRequestIfUserIsInactiveOnLogin()
        {
            var existentUser = new User
            {
                Id = "asdf-aewrwe-asdfa",
                Email = "testando@gmail.com",
                IsActive = false
            };
            var viewModel = new SigninViewModel
            {
                Email = "testando@gmail.com",
                Password = "somepassword"
            };

            var mockForDomainUserService = new Mock<IUserService>();
            mockForDomainUserService.Setup(service => service.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(existentUser)
                .Verifiable();

            var controller = new UserController(
                mockForDomainUserService.Object,
                null, null, null);

            var result = await controller.Login(viewModel);
            var resultData = result as BadRequestObjectResult;
            string error = resultData.Value?.GetType().GetProperty("error_description")?.GetValue(resultData.Value, null).ToString();

            Assert.IsInstanceOfType(resultData, typeof(BadRequestObjectResult));
            Assert.AreEqual(resultData.StatusCode, 400);
            Assert.AreEqual(error, "Usuario não esta ativo");
            mockForDomainUserService.VerifyAll();
        }

        [TestMethod]
        public async Task IShouldReturnBadRequestIfCredentialsAreIncorrectOnLogin()
        {
            var existentUser = new User
            {
                Id = "asdf-aewrwe-asdfa",
                Email = "testando@gmail.com",
                IsActive = true
            };
            var viewModel = new SigninViewModel
            {
                Email = "testando@gmail.com",
                Password = "somepassword"
            };

            var mockForDomainUserService = new Mock<IUserService>();
            mockForDomainUserService.Setup(service => service.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(existentUser)
                .Verifiable();

            mockForDomainUserService.Setup(service => service.DoLogin(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(false)
                .Verifiable();

            var controller = new UserController(
                mockForDomainUserService.Object,
                null, null, null);

            var result = await controller.Login(viewModel);
            var resultData = result as BadRequestObjectResult;
            string error = resultData.Value?.GetType().GetProperty("error_description")?.GetValue(resultData.Value, null).ToString();

            Assert.IsInstanceOfType(resultData, typeof(BadRequestObjectResult));
            Assert.AreEqual(resultData.StatusCode, 400);
            Assert.AreEqual(error, "Email ou senha inválida");
            mockForDomainUserService.VerifyAll();
        }
    }
}
