using System.Threading.Tasks;
using u = Core.Transactional;
using Infrastructure.Database;
using Core.Data;
using Infrastructure.Database.Entities;
using System;
using Infrastructure.Essentials;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Requests
{
    public class GetUserRequest : IAyncRequest<u.User>
    {
        readonly int? id;
        readonly IDbOption option;

        public GetUserRequest(int? id, IDbOption option)
            => (this.id, this.option) = (id, option);

        public async Task<AsyncData<u.User>> RunAsync()
        {
            try
            {
                using var db = new ApplicationContext(option);
                User result = id switch
                {
                    int userId => await db.Users.FirstAsync(p => p.Id == userId),
                    null => await db.Users.FirstAsync(p => p.IsDefault == true)
                };

                return AsyncData<u.User>.Loaded(result.ToCore());
            }
            catch (Exception e)
            {
                return AsyncData<u.User>.ErrorMessage(e.Message);
            }
        }

    }
}
