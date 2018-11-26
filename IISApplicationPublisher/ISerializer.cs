namespace IISApplicationPublisher
{
    public interface ISerializer
    {
        T Deserialize<T>(string input);
    }
}