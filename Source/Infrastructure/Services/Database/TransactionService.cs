using Core.Data;
using Core.Services;
using Core.Transactional;
using Infrastructure.Essentials;
using Infrastructure.Requests;
using System.Threading.Tasks;

namespace Infrastructure.Services.Database
{
    public class TransactionService : ITransactionService
    {
        readonly IDbOption options;
        public TransactionService(IDbOption option) => options = option;

        public Task<AsyncData<Transaction>> Add(Transaction transaction)
            => new AddTransactionRequest(1, transaction, options).RunAsync();
        
    }
}
