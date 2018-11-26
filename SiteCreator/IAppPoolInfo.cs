namespace SiteCreator
{
    public interface IAppPoolInfo
    {
        string AppPoolName { get; }
        string ManagedRuntimeVersion { get; }
    }
}