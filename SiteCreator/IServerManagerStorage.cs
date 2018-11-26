using Microsoft.Web.Administration;

namespace SiteCreator
{
    public interface IServerManagerStorage
    {
        ServerManager Get();
    }
}