namespace SiteCreator
{
    public class AppPoolCreator : IAppPoolCreator
    {
        private readonly IServerManagerStorage _serverManagerStorage;

        public AppPoolCreator(IServerManagerStorage serverManagerStorage)
        {
            _serverManagerStorage = serverManagerStorage;
        }

        public void Create(IAppPoolInfo appPoolInfo)
        {
            var serverManager = _serverManagerStorage.Get();
            if (serverManager.ApplicationPools[appPoolInfo.AppPoolName] == null)
            {
                var iisAppPool = serverManager.ApplicationPools.Add(appPoolInfo.AppPoolName);
                iisAppPool.ManagedRuntimeVersion = appPoolInfo.ManagedRuntimeVersion;
            }
        }
    }
}