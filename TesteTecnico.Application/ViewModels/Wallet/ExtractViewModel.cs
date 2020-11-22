using System.Collections.Generic;

namespace TesteTecnico.Application.ViewModels.Wallet
{
    public class ExtractViewModel
    {
        public decimal DotzBalance { get; set; }

        public IEnumerable<ExtractItemViewModel> HistoryTransactions { get; set; }
    }
}
