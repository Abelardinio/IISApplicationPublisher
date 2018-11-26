using System;
using System.Linq;

namespace SiteCreator
{
    public class DefaultSiteCreator : ISiteCreator
    {
        private readonly IApplicationCreator _applicationCreator;
        private readonly IServerManagerCreator _serverManagerCreator;

        public DefaultSiteCreator(IServerManagerCreator serverManagerCreator, IApplicationCreator applicationCreator)
        {
            _serverManagerCreator = serverManagerCreator;
            _applicationCreator = applicationCreator;
        }

        public void Create(IApplication[] applications)
        {
            using (_serverManagerCreator.Create())
            {
                if (applications.Any(x =>x.Applications.Any(y=>y.Applications.Any())))
                    throw new Exception("Site can only contain applications which does not contain any applications.");

                foreach (var application in applications)
                {
                    _applicationCreator.Create(application);
                }

                _serverManagerCreator.CommitChanges();
            }
        }
    }
}