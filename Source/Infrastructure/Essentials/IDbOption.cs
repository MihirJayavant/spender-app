namespace Infrastructure.Essentials
{
    public interface IDbOption
    {
        string AppDataDirectory { get; }
        string DatabaseName { get; }
    }
}