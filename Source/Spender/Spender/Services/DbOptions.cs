using Infrastructure.Essentials;
using Xamarin.Essentials;

namespace Spender.Services
{
    public class DbOptions : IDbOption
    {
        public string AppDataDirectory => FileSystem.AppDataDirectory;
        public string DatabaseName => "spender.db3";
    }
}
