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

        public Task<AsyncData<Transaction>> Add(int divisionId,Transaction transaction)
            => new AddTransactionRequest(divisionId, transaction, options).RunAsync();

        public async Task<AsyncData<PaginatedResult<Transaction>>> GetAll(int divisionId, int limit, int offest)
            => await new GetTransactionRequest(new Paginated<int>(divisionId, limit, offest), options)
                            .RunAsync();
    }
}
