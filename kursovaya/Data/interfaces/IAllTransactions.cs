using rlf.Data.Models;

namespace rlf.Data.interfaces
{
    public interface IAllTransactions
    {
        IEnumerable<Transaction> Transactions { get; }
        Transaction GetObgectTransaction(int transactionId);

    }
}
