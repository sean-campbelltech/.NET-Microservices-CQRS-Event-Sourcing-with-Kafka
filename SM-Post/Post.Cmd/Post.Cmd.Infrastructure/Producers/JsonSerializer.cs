using System.Text;
using System.Text.Json;
using Confluent.Kafka;

namespace Post.Cmd.Infrastructure.Producers
{
    public class JsonSerializer<T> : ISerializer<T> where T : class
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            if (data == null)
            {
                return null;
            }

            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));
        }
    }
}