using Newtonsoft.Json;

namespace IISApplicationPublisher
{
    public class Serializer : ISerializer
    {
        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}