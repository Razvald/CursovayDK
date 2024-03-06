using Microsoft.EntityFrameworkCore;
using rlf.Data;
using rlf.Data.interfaces;
using rlf.Data.Models;

namespace rlf.Data.Repository
{
    public class AllTransactions(AppDBContent appDBContent) : IAllTransactions
    {
        private readonly AppDBContent _appDBContent = appDBContent;

        public IEnumerable<Transaction> Transactions => _appDBContent.Transaction.ToList();

        public Transaction GetObgectTransaction(int transactionId)
        {
            return _appDBContent.Transaction.FirstOrDefault(t => t.Id == transactionId);
        }
    }
}
