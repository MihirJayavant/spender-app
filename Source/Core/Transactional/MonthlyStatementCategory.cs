

namespace Core.Transactional
{
    public class MonthlyStatementCategory
    {
        public Category Category { get; }
        public int TransactionCount { get; }
        public double Amount { get; }

        public MonthlyStatementCategory(Category category, int transactionCount, double amount)
            => (Category, TransactionCount, Amount) = (category, transactionCount, amount);
    }
}
