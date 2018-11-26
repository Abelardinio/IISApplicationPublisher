using System;
using Microsoft.Web.Administration;

namespace SiteCreator
{
    public class ServerManagerCreator : IServerManagerCreator, IServerManagerStorage
    {
        private ServerManager _manager;
        public IDisposable Create()
        {
            _manager = new ServerManager();
            return _manager;
        }

        public void CommitChanges()
        {
           _manager.CommitChanges();
        }

        public ServerManager Get()
        {
            return _manager;
        }
    }
}