
using System.Threading.Tasks;
using u = Core.User;
using Infrastructure.Database;
using Core.AsyncData;
using Infrastructure.Database.Entities;
using System;
using Infrastructure.Essentials;

namespace Infrastructure.Requests
{
    public class AddUserRequest : IAyncRequest<u.User>
    {
        readonly User user;
        readonly IDbOption option;

        public AddUserRequest(User user, IDbOption option)
            => (this.user, this.option) = (user, option);

        public async Task<AsyncData<u.User>> RunAsync()
        {
            try 
            {
                using var db = new ApplicationContext(option);
                var r = await db.Users.AddAsync(user);
                return AsyncData<u.User>.Loaded(r.Entity.ToCore());
            }
            catch(Exception e)
            {
                return AsyncData<u.User>.ErrorMessage(e.Message);
            }
        }
    }
}