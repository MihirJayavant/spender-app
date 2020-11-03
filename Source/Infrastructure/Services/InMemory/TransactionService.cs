

using Core.Data;
using Core.Services;
using Core.Transactional;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Infrastructure.Services.InMemory
{
    public class TransactionService : ITransactionService
    {

        readonly IList<Transaction> transactions = new List<Transaction>();

        public TransactionService()
        {
        }

        public Task<AsyncData<Transaction>> Add(Transaction transaction)
        {
            transactions.Add(transaction);
            return Task.FromResult(AsyncData<Transaction>.Loaded(transaction));
        }
    }
}
