using System.IO;
using System.Linq;

namespace SiteCreator
{
    public class ApplicationCreator : IApplicationCreator
    {
        private readonly IAppPoolCreator _appPoolCreator;
        private readonly IServerManagerStorage _serverManagerStorage;

        public ApplicationCreator(IAppPoolCreator appPoolCreator, IServerManagerStorage serverManagerStorage)
        {
            _appPoolCreator = appPoolCreator;
            _serverManagerStorage = serverManagerStorage;
        }

        public void Create(IApplication application, IApplication parent = null)
        {
            _appPoolCreator.Create(application);

            var serverManager = _serverManagerStorage.Get();

            if (parent != null)
            {
                var parentSite = serverManager.Sites[parent.Name];
                var app = parentSite.Applications.FirstOrDefault(x=>x.Path == Path.GetFullPath(application.Path));

                if (app == null)
                {
                    app = parentSite.Applications.Add("/" + application.Name, Path.GetFullPath(application.Path));
                    app.ApplicationPoolName = application.AppPoolName;
                }
            }
            else
            {
                var iisSite = serverManager.Sites[application.Name];

                if (iisSite == null)
                {
                    iisSite = serverManager.Sites.Add(application.Name, "http", $"*:80:{application.Name}",
                        Path.GetFullPath(application.Path));
                    iisSite.ApplicationDefaults.ApplicationPoolName = application.AppPoolName;
                }
            }

            foreach (var app in application.Applications)
            {
                Create(app, application);
            }
        }
    }
}