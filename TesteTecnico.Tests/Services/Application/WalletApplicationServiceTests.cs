using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using TesteTecnico.Application.Services;
using TesteTecnico.Application.ViewModels.Wallet;
using TesteTecnico.Domain.Core.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Tests.Services.Application
{
    [TestClass]
    public class WalletApplicationServiceTests
    {
        [TestMethod]
        public async Task IShouldCanSeeWalletBalance()
        {
            var user = new User
            {
                Wallet = new Wallet
                {
                    DotzBalance = 10
                }
            };

            var mockForUserService = new Mock<IUserService>();
            mockForUserService.Setup(d => d.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(user)
                .Verifiable();

            var service = new WalletApplicationService(mockForUserService.Object);

            var result = await service.GetBalance(It.IsAny<string>());

            Assert.IsInstanceOfType(result, typeof(BalanceViewModel));
            Assert.AreEqual(result.DotzBalance, user.Wallet.DotzBalance);
        }
    }
}
