

using Core.Data;
using Core.Services;
using Core.Transactional;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace Infrastructure.Services.InMemory
{
    public class TransactionService : ITransactionService
    {

        readonly IList<Transaction> transactions = new List<Transaction>();

        public TransactionService()
        {
        }

        public Task<AsyncData<Transaction>> Add(int divisionId, Transaction transaction)
        {
            transactions.Add(transaction);
            return Task.FromResult(AsyncData<Transaction>.Loaded(transaction));
        }

        public Task<AsyncData<PaginatedResult<Transaction>>> GetAll(int divisionId, int limit, int offest)
        {
            var result = transactions.Take(limit)
                                    .Skip(offest)
                                    .ToList();
            return Task.FromResult(new AsyncData<PaginatedResult<Transaction>>(
                new PaginatedResult<Transaction>(result, limit, offest)
                ));
        }
    }
}
