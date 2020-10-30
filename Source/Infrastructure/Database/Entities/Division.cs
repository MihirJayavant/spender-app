using System;
using System.Collections.Generic;
using t = Core.Transactional;

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

        public t.Division ToCore()
    => new t.Division(id: Id, title: Title, additionalNotes: AdditionalNotes, 
                category: t.Categories.Parse(Category), created: Created, lastTransactionDate: LastTransactionDate);

        public static Division Parse(t.Division division) => new Division
        {
            Id = division.Id,
            Title = division.Title,
            AdditionalNotes = division.AdditionalNotes,
            Category = division.Category.Name,
            Created = division.Created,
            LastTransactionDate = division.LastTransactionDate
        };
    }
}
