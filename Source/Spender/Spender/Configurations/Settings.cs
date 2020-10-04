

namespace Spender.Configurations
{
    public interface ISettings
    {
        bool IsLocalDev { get; }
        bool UseDatabase { get; }
        public bool HasDefaultUser { get; }
    }

    public class DevSettings : ISettings
    {
        public bool IsLocalDev => true;
        public bool UseDatabase => true;
        public bool HasDefaultUser => false;
    }

    public class ProdSettings : ISettings
    {
        public bool IsLocalDev => true;
        public bool UseDatabase => true;
        public bool HasDefaultUser => false;
    }
}
