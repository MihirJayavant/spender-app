using Core.Data;
using Core.Services;
using Core.Transactional;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.InMemory
{
    public class UserService : IUserService
    {
        readonly IList<User> users = new List<User>();
        public UserService() { }

        public bool IsUserCreated => users.Count > 0;

        public async Task<AsyncData<User>> Add(string name)
        {
            var user = new User(1, name, true, DateTime.Now);
            users.Add(user);
            await Task.Delay(1000);
            return AsyncData<User>.Loaded(user);
        }

    }
}
