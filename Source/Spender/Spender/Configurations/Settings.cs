

namespace Spender.Configurations
{
    public interface ISettings
    {
        bool IsLocalDev { get; }
        bool UseDatabase { get; }
        public bool IsFirstTime { get; }
    }

    public class DevSettings : ISettings
    {
        public bool IsLocalDev => true;
        public bool UseDatabase => true;
        public bool IsFirstTime => false;
    }

    public class ProdSettings : ISettings
    {
        public bool IsLocalDev => true;
        public bool UseDatabase => true;
        public bool IsFirstTime => true;
    }
}
