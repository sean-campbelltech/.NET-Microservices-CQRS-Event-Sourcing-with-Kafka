using System.Text.Json;
using System.Text.Json.Serialization;
using CQRS.Core.Events;
using Post.Common.Events;

namespace Post.Query.Infrastructure.Converters
{
    public class EventJsonConverter : JsonConverter<BaseEvent>
    {
        public override bool CanConvert(Type type)
        {
            return type.IsAssignableFrom(typeof(BaseEvent));
        }

        public override BaseEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonDocument.TryParseValue(ref reader, out var doc))
            {
                if (doc.RootElement.TryGetProperty("Type", out var type))
                {
                    var typeValue = type.GetString();
                    var rootElement = doc.RootElement.GetRawText();

                    return typeValue switch
                    {
                        nameof(PostCreatedEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(rootElement, options),
                        nameof(MessageUpdatedEvent) => JsonSerializer.Deserialize<MessageUpdatedEvent>(rootElement, options),
                        nameof(PostLikedEvent) => JsonSerializer.Deserialize<PostLikedEvent>(rootElement, options),
                        nameof(CommentAddedEvent) => JsonSerializer.Deserialize<CommentAddedEvent>(rootElement, options),
                        nameof(CommentUpdatedEvent) => JsonSerializer.Deserialize<CommentUpdatedEvent>(rootElement, options),
                        nameof(CommentRemovedEvent) => JsonSerializer.Deserialize<CommentRemovedEvent>(rootElement, options),
                        nameof(PostRemovedEvent) => JsonSerializer.Deserialize<PostRemovedEvent>(rootElement, options),
                        _ => throw new JsonException($"{typeValue} is not supported yet!")
                    };
                }

                throw new JsonException("Could not find Type property!");
            }

            throw new JsonException("Failed to parse JsonDocument");
        }

        public override void Write(Utf8JsonWriter writer, BaseEvent value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}