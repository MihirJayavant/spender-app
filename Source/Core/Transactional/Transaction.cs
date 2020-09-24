

using System;

namespace Core.Transactional
{
    public sealed class Transaction
    {
        public int Id { get; }
        public int UserId { get; }
        public string Title { get; }
        public double Amount { get; }
        public DateTime Date { get; }
        public ICategory Category { get; }

        public Transaction(int id, int userId, string title, double amount, ICategory category, DateTime date)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Amount = amount;
            Category = category;
            Date = date;
        }

        public override bool Equals(object? obj)
            => obj switch
            {
                Transaction t => this == t,
                _ => false
            };

        public override int GetHashCode()
            => Id ^ Title.GetHashCode() ^ Amount.GetHashCode() ^ Date.GetHashCode();

        public static bool operator ==(Transaction t1, Transaction t2)
            => (t1.Id, t1.UserId, t1.Title, t1.Amount, t1.Date) == (t2.Id, t2.UserId, t2.Title, t2.Amount, t2.Date);

        public static bool operator !=(Transaction t1, Transaction t2)
            => !(t1 == t2);
    }
}
