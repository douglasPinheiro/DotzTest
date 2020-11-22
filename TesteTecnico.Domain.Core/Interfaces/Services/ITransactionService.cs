using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Core.Interfaces.Services
{
    public interface ITransactionService
    {
        void Buy(Transaction transaction);

        void Exchange(Transaction transaction);
    }
}
