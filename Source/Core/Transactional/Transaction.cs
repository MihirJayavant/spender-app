

using System;

namespace Core.Transactional
{
    public sealed class Transaction
    {
        public int Id { get; }
        public string Title { get; }
        public double Amount { get; }
        public DateTime Date { get; }

        public Transaction(int id, string title, double amount, DateTime date)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Date = date;
        }

    }
}
