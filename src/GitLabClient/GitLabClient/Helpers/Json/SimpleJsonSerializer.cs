namespace GitLabClient
{
    using Newtonsoft.Json;

    public class SimpleJsonSerializer : IJsonSerializer
    {
        public string Serialize(object item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
