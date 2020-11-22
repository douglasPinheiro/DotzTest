using System.Threading.Tasks;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.ViewModels.Transaction;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Domain.Entities;
using TesteTecnico.Domain.Enums;

namespace TesteTecnico.Application.Services
{
    public class TransactionApplicationService : ITransactionApplicationService
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ITransactionService _transactionService;

        public TransactionApplicationService(
            IUserService userService,
            IProductService productService,
            ITransactionService transactionService)
        {
            _userService = userService;
            _productService = productService;
            _transactionService = transactionService;
        }

        public async Task Buy(string userEmail, BuyViewModel viewModel)
        {
            var user = await _userService.GetUserByEmail(userEmail);
            var product = _productService.GetById(viewModel.ProductId);
            var transaction = new Transaction
            {
                Company = product.Company,
                Product = product,
                DotzCost = product.RewardInDotz,
                Wallet = user.Wallet
            };
            _transactionService.Buy(transaction);
        }

        public async Task Exchange(string userEmail, ExchangeViewModel viewModel)
        {
            var user = await _userService.GetUserByEmail(userEmail);
            var product = _productService.GetById(viewModel.ProductId);
            var transaction = new Transaction
            {
                Company = product.Company,
                Product = product,
                DotzCost = viewModel.DotzCost,
                Wallet = user.Wallet
            };
            _transactionService.Exchange(transaction);
        }
    }
}
