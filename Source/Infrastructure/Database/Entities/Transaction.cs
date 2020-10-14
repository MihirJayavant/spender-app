using System;

using core = Core.Transactional;

namespace Infrastructure.Database.Entities
{
    public class Transaction : AuditableEntity
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Category { get; set; }
        
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        public core.Transaction GetCore()
            => new core.Transaction
            (
                id: Id, title: Title, amount: Amount, date: TransactionDate
            );
    }
}
