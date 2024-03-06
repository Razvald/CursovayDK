using rlf.Data.Models;

namespace rlf.Data.interfaces
{
    public interface ITransactionsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}