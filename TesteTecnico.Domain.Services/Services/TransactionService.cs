using System;
using TesteTecnico.Domain.Core.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Domain.Entities;
using TesteTecnico.Domain.Enums;

namespace TesteTecnico.Domain.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Buy(Transaction transaction)
        {
            transaction.TransactionType = TransactionType.Buy;
            transaction.CreatedAt = DateTime.Now;
            _unitOfWork.Transactions.Add(transaction);

            var wallet = transaction.Wallet;
            wallet.DotzBalance += transaction.DotzCost;
            
            _unitOfWork.SaveChanges();
        }

        public void Exchange(Transaction transaction)
        {
            transaction.TransactionType = TransactionType.Exchange;
            transaction.CreatedAt = DateTime.Now;
            _unitOfWork.Transactions.Add(transaction);

            if (transaction.Wallet.DotzBalance < transaction.DotzCost)
                throw new Exception("Saldo insuficiente para fazer a troca");

            var wallet = transaction.Wallet;
            wallet.DotzBalance -= transaction.DotzCost;

            _unitOfWork.SaveChanges();
        }
    }
}
