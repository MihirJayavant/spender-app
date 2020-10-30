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
    public class GetDivisionRequest : IAyncRequest<IList<t.Division>>
    {
        readonly int userId;
        readonly IDbOption option;

        public GetDivisionRequest(int userId, IDbOption option)
            => (this.userId, this.option) = (userId, option);

        public async Task<AsyncData<IList<t.Division>>> RunAsync()
        {
            try
            {
                using var db = new ApplicationContext(option);
                var result = await db.Divisions
                                .Where(d => d.UserId == userId)
                                .Select(d => d.ToCore())
                                .ToListAsync();
                return AsyncData<IList<t.Division>>.Loaded(result);
            }
            catch (Exception e)
            {
                return AsyncData<IList<t.Division>>.ErrorMessage(e.Message);
            }
        }

    }
}
