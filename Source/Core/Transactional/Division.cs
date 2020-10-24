

using System;

namespace Core.Transactional
{
    public class Division
    {
        public int Id { get; }
        public string Title { get; }
        public string AdditionalNotes { get; }
        public ICategory Category { get; }
        public DateTime Created { get; }
        public DateTime LastTransactionDate { get; }

        public Division(int id, string title, string additionalNotes, 
                            ICategory category, DateTime created, DateTime lastTransactionDate)
        {
            Id = id;
            Title = title;
            AdditionalNotes = additionalNotes;
            Category = category;
            Created = created;
            LastTransactionDate = lastTransactionDate;
        }

    }
}
