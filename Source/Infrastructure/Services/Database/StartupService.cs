
using Core.Services;
using Infrastructure.Database;
using Infrastructure.Essentials;
using System.Threading.Tasks;

namespace Infrastructure.Services.Database
{
    public class StartupService : IStartupService
    {
        readonly IDbOption options;
        public StartupService(IDbOption options)
            => this.options = options;

        public async Task EnsureCreation()
        {
            using var db = new ApplicationContext(options);
            await db.EnsureDbAsync();
        }
    }
}
