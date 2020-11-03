using System.Threading.Tasks;
using t = Core.Transactional;
using Infrastructure.Database;
using Core.Data;
using System;
using Infrastructure.Essentials;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Infrastructure.Requests
{

    public class GetTransactionRequest : IAyncRequest<Paginated<IList<t.Transaction>>>
    {
        readonly Paginated<int> payload;
        readonly IDbOption option;

        public GetTransactionRequest(Paginated<int> payload, IDbOption option)
            => (this.payload, this.option) = (payload, option);

        public async Task<AsyncData<Paginated<IList<t.Transaction>>>> RunAsync()
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
                return AsyncData<Paginated<IList<t.Transaction>>>.Loaded(
                    new Paginated<IList<t.Transaction>>(result, payload.Limit, payload.Offset)
                    );
            }
            catch (Exception e)
            {
                return AsyncData<Paginated<IList<t.Transaction>>>.ErrorMessage(e.Message);
            }
        }

    }
}
