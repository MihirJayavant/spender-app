

using System.Threading.Tasks;

namespace Core.Services
{
    public interface IStartupService
    {
        Task EnsureCreation();
    }

}
