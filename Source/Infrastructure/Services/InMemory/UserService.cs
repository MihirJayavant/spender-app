using Core.Data;
using Core.Services;
using Core.Transactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.InMemory
{
    public class UserService : IUserService
    {
        readonly IList<User> users = new List<User>();
        public UserService() 
        {
            for(int i = 1; i <= 5; i++)
            {
                users.Add(new User(i, $"Mihir {i}", i == 1 , DateTime.Now));
            }
            
        }

        public bool IsUserCreated => true;
        public User User { get; set; }

        public async Task<AsyncData<User>> Add(string name)
        {
            var id = users.Count + 1;
            var user = new User(id, name, true, DateTime.Now);
            users.Add(user);
            await Task.Delay(1000);
            return AsyncData<User>.Loaded(user);
        }

        public Task<AsyncData<User>> Get(int? id)
        {
            var result = id switch
            {
                int userId => users.First(p => p.Id == id),
                null => users.First(p => p.IsDefault)
            };
            return Task.FromResult(AsyncData<User>.Loaded(result));
        }
    }
}
