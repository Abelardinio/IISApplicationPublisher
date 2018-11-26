using System.IO;

namespace IISApplicationPublisher
{
    public class Configuration : IConfiguration
    {
        private readonly IConfigurationModel _model;

        public Configuration(ISerializer serializer)
        {
            var input = File.ReadAllText(@"configuration.json");

            _model = serializer.Deserialize<ConfigurationModel>(input);
        }

        public IConfigurationModel Get()
        {
            return _model;
        }
    }
}