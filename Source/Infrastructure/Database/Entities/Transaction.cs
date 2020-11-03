using System;

using core = Core.Transactional;

namespace Infrastructure.Database.Entities
{
    public class Transaction : AuditableEntity
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        public core.Transaction ToCore()
            => new core.Transaction
            (
                id: Id, title: Title, amount: Amount, date: TransactionDate
            );

        public static Transaction Parse(core.Transaction transaction)
            => new Transaction
            {
                Id = transaction.Id,
                Title = transaction.Title,
                Amount = transaction.Amount,
                TransactionDate = transaction.Date
            };
    }
}
