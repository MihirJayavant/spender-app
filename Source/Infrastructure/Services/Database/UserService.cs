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
        readonly ILocalStorage localStorage;
        public UserService(IDbOption option, ILocalStorage localStorage) 
            => (dbOption, this.localStorage) = (option, localStorage);

        public bool IsUserCreated => localStorage.Get("IsUserCreated", false);
        public User User { get; set; }

        public async Task<AsyncData<User>> Add(string name)
        {
            var result = await new AddUserRequest(name, dbOption).RunAsync();
            if(result.State == AsyncDataState.Loaded)
                localStorage.Set("IsUserCreated", true);
            return result;
        }

        public async Task<AsyncData<User>> Get(int? id) => await new GetUserRequest(id, dbOption).RunAsync();
    }
}
