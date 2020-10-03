using System;

namespace Infrastructure.Database.Entities
{
    public class Receiver : AuditableEntity
    {
        public string Title { get; set; }
        public string AdditionalNotes { get; set; }
        public string Category { get; set; }
        public DateTime LastTransactionDate { get; set; }
    }
}
