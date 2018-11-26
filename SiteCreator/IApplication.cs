namespace SiteCreator
{
    public interface IApplication : IAppPoolInfo
    {
        string Name { get; }
        string Path { get; }
        IApplication[] Applications { get; }
    }
}