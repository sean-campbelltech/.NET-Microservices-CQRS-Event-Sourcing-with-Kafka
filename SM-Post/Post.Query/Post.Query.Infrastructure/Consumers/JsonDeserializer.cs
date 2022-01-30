using System.Text;
using System.Text.Json;
using Confluent.Kafka;

namespace Post.Query.Infrastructure.Consumers
{
    public class JsonDeserializer<T> : IDeserializer<T> where T : class
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (data == null)
            {
                return null;
            }

            return JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(data.ToArray()));
        }
    }
}