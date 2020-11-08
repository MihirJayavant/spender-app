using System.Threading.Tasks;
using t = Core.Transactional;
using Infrastructure.Database;
using Core.Data;
using System;
using Infrastructure.Essentials;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Requests
{

    public class GetTransactionRequest : IAyncRequest<PaginatedResult<t.Transaction>>
    {
        readonly Paginated<int> payload;
        readonly IDbOption option;

        public GetTransactionRequest(Paginated<int> payload, IDbOption option)
            => (this.payload, this.option) = (payload, option);

        public async Task<AsyncData<PaginatedResult<t.Transaction>>> RunAsync()
        {
            try
            {
                using var db = new ApplicationContext(option);
                var result = await db.Transactions
                                .Where(d => d.DivisionId == payload.Data)
                                .Skip(payload.Offset)
                                .Take(payload.Limit)
                                .Select(d => d.ToCore())
                                .ToListAsync();
                return AsyncData<PaginatedResult<t.Transaction>>.Loaded(
                    new PaginatedResult<t.Transaction>(result, payload.Limit, payload.Offset)
                    );
            }
            catch (Exception e)
            {
                return AsyncData<PaginatedResult<t.Transaction>>.ErrorMessage(e.Message);
            }
        }

    }
}
