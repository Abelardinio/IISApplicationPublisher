using SiteCreator;

namespace IISApplicationPublisher
{
    public class Application : IApplication
    {
        public string Name { get; set; }
        public string AppPoolName { get; set; }
        public string ManagedRuntimeVersion { get; set; }
        public string Path { get; set; }
        public Application[] Applications { get; set; }
        IApplication[] IApplication.Applications => Applications;
    }
}