using System.Collections.Generic;
using Newtonsoft.Json;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.Common
{
    internal class EventSerializer : IEventSerializer
    {
        private readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        private readonly JsonSerializerSettings _deserializationSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public string Serialize(object events)
        {
            return JsonConvert.SerializeObject(events, _serializationSettings);
        }

        public IEnumerable<Event> Deserialize(string events)
        {
            return JsonConvert.DeserializeObject<Event[]>(events, _deserializationSettings);
        }
    }
}