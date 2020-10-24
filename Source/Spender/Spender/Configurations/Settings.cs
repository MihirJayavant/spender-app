

namespace Spender.Configurations
{
    public interface ISettings
    {
        bool IsLocalDev { get; }
        bool UseDatabase { get; }
        bool UseEssentials { get; }
    }

    public class DevSettings : ISettings
    {
        public bool IsLocalDev => true;
        public bool UseDatabase => false;
        public bool UseEssentials => false;
    }

    public class ProdSettings : ISettings
    {
        public bool IsLocalDev => false;
        public bool UseDatabase => true;
        public bool UseEssentials => true;
    }
}
