using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using TesteTecnico.Api.Controllers;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.ViewModels.Wallet;

namespace TesteTecnico.Tests.Controllers
{
    [TestClass]
    public class WalletControllerTests
    {
        [TestMethod]
        public async Task IShouldCanSeeTheWalletBalance()
        {
            var viewModel = new BalanceViewModel { DotzBalance = 10 };

            var mockForWalletService = new Mock<IWalletApplicationService>();
            mockForWalletService.Setup(d => d.GetBalance(It.IsAny<string>()))
                .ReturnsAsync(viewModel)
                .Verifiable();

            var mockForHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockForHttpContextAccessor.Setup(d => d.HttpContext.User.Identity.Name)
                .Returns(It.IsAny<string>())
                .Verifiable();

            var controller = new WalletController(
                mockForWalletService.Object,
                mockForHttpContextAccessor.Object);

            var result = await controller.Balance();
            var resultOk = result as OkObjectResult;
            var resultData = resultOk.Value as BalanceViewModel;

            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(resultOk.StatusCode, 200);
            Assert.AreEqual(resultData.DotzBalance, viewModel.DotzBalance);
            mockForWalletService.VerifyAll();
        }

        [TestMethod]
        public async Task IShouldCanSeeTheWalletExtract()
        {
            var viewModel = new ExtractViewModel();

            var mockForWalletService = new Mock<IWalletApplicationService>();
            mockForWalletService.Setup(d => d.GetExtract(It.IsAny<string>()))
                .ReturnsAsync(viewModel)
                .Verifiable();

            var mockForHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockForHttpContextAccessor.Setup(d => d.HttpContext.User.Identity.Name)
                .Returns(It.IsAny<string>())
                .Verifiable();

            var controller = new WalletController(
                mockForWalletService.Object,
                mockForHttpContextAccessor.Object);

            var result = await controller.Extract();
            var resultOk = result as OkObjectResult;
            var resultData = resultOk.Value as BalanceViewModel;

            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(resultOk.StatusCode, 200);
            mockForWalletService.VerifyAll();
        }
    }
}
