using System.Collections.Generic;

namespace Core.Transactional
{
    public sealed class MonthlyStatement
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double DebitedAmount { get; }
        public double CreditedAmount { get; }
        public int TotalDebitedTransactions { get; }
        public int TotalCreditedTransactions { get; }

        private readonly List<MonthlyStatementCategory> categories = new List<MonthlyStatementCategory>();
        public IReadOnlyList<MonthlyStatementCategory> Categories => categories.AsReadOnly();

    }
}
