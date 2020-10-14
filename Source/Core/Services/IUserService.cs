using Core.Data;
using Core.Transactional;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<AsyncData<User>> Add(string user);
        bool IsUserCreated { get; }
    }
}