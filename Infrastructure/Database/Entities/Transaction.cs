using System;

using core = Core.Transaction;

namespace Infrastructure.Database.Entities
{
    public class Transaction : AuditableEntity
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public core.Transaction GetCore()
            => new core.Transaction
            (
                id: Id, userId: UserId, title: Title, 
                amount: Amount, category: null, date: TransactionDate
            );
    }
}
