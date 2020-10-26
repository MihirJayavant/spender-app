

using Core.Services;
using System.Threading.Tasks;

namespace Infrastructure.Services.InMemory
{
    public class StartupService : IStartupService
    {
        public Task EnsureCreation() => Task.CompletedTask;
    }
}
