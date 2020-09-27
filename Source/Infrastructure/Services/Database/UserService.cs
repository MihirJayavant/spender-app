using Core.Data;
using Core.Services;
using Core.Transactional;
using Infrastructure.Essentials;
using Infrastructure.Requests;
using System.Threading.Tasks;

namespace Infrastructure.Services.Database
{
    public class UserService : IUserService
    {
        readonly IDbOption dbOption;
        public UserService(IDbOption option) => dbOption = option;

        public async Task<AsyncData<User>> Add(User user) 
            => await new AddUserRequest(user, dbOption).RunAsync();
        
    }
}
