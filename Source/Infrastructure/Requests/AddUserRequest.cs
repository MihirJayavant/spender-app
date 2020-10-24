
using System.Threading.Tasks;
using u = Core.Transactional;
using Infrastructure.Database;
using Core.Data;
using Infrastructure.Database.Entities;
using System;
using Infrastructure.Essentials;

namespace Infrastructure.Requests
{
    public class AddUserRequest : IAyncRequest<u.User>
    {
        readonly string name;
        readonly IDbOption option;

        public AddUserRequest(string name, IDbOption option)
            => (this.name, this.option) = (name, option);

        public async Task<AsyncData<u.User>> RunAsync()
        {
            try 
            {
                using var db = new ApplicationContext(option);
                var result = await db.Users.AddAsync(new User { Name=name, IsDefault=true });
                return AsyncData<u.User>.Loaded(result.Entity.ToCore());
            }
            catch(Exception e)
            {
                return AsyncData<u.User>.ErrorMessage(e.Message);
            }
        }

    }
}