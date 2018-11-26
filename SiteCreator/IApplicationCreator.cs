namespace SiteCreator
{
    public interface IApplicationCreator
    {
        void Create(IApplication application, IApplication parent = null);
    }
}