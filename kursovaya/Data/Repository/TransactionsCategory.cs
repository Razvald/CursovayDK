using rlf.Data;
using rlf.Data.interfaces;
using rlf.Data.Models;

namespace rlf.Data.Repository
{
    public class TransactionsCategory(AppDBContent appDBContent) : ITransactionsCategory
    {
        private readonly AppDBContent _appDBContent = appDBContent;

        public IEnumerable<Category> AllCategories => _appDBContent.Category.ToList();
    }
}
