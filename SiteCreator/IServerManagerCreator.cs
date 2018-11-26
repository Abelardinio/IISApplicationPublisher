using System;
using Microsoft.Web.Administration;

namespace SiteCreator
{
    public interface IServerManagerCreator
    {
        IDisposable Create();

        void CommitChanges();
    }
}