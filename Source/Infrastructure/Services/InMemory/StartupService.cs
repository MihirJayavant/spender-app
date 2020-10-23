

using Core.Services;
using System.Threading.Tasks;

namespace Infrastructure.Services.InMemory
{
    public class StartupService : IStartupService
    {
        public async Task EnsureCreation()
        {
            await Task.FromResult(true);
        }
    }
}
