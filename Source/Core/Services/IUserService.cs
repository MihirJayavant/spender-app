using Core.Data;
using Core.Transactional;

namespace Core.Services
{
    public interface IUserService
    {
        AsyncData<User> Add(User transaction);
    }
}