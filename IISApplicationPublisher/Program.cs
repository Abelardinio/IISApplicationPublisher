using System.IO;
using SiteCreator;

namespace IISApplicationPublisher
{
    class Program
    {
        private static readonly ServerManagerCreator ServerManagerCreator = new ServerManagerCreator();
        private static readonly IAppPoolCreator AppPoolCreator = new AppPoolCreator(ServerManagerCreator);
        private static readonly IApplicationCreator ApplicationCreator =  new ApplicationCreator(AppPoolCreator, ServerManagerCreator);
        private static readonly ISiteCreator SiteCreator = new DefaultSiteCreator(ServerManagerCreator, ApplicationCreator);
        private static readonly ISerializer Serializer = new Serializer();
        static void Main(string[] args)
        {
            var configurationJson = File.ReadAllText("configuration.json");
            var model = Serializer.Deserialize<ConfigurationModel>(configurationJson);

            //SiteCreator.Create(model.Applications);
        }
    }
}
