using System;
using System.Collections.Generic;

namespace Infrastructure.Database.Entities
{
    public class Division : AuditableEntity
    {
        public string Title { get; set; }
        public string AdditionalNotes { get; set; }
        public string Category { get; set; }
        public DateTime LastTransactionDate { get; set; }
        public List<Transaction> Transactions { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
