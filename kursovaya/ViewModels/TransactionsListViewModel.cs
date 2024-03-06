using rlf.Data.Models;

namespace rlf.ViewModels
{
    public class TransactionsListViewModel
    {
        public IEnumerable<Transaction> GetAllTransactions {  get; set; }

        public string TrnsCategory { get; set; }

        public int UserId { get; set; } = 0;
        public decimal TotalIncome { get; internal set; }
        public decimal TotalExpense { get; internal set; }
        public decimal Balance { get; internal set; }
    }
}
