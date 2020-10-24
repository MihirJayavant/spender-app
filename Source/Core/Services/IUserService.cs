using Core.Data;
using Core.Transactional;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        User User { get; set; }
        bool IsUserCreated { get; }
        Task<AsyncData<User>> Add(string user);
        Task<AsyncData<User>> Get(int? id);
    }
}