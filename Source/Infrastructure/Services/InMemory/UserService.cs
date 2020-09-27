using Core.Data;
using Core.Services;
using Core.Transactional;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.InMemory
{
    public class UserService : IUserService
    {
        readonly IList<User> users = new List<User>();
        public UserService() { }

        public async Task<AsyncData<User>> Add(User user)
        {
            users.Add(user);
            await Task.Delay(1000);
            return AsyncData<User>.Loaded(user);
        }

    }
}
