using System.Collections.Generic;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.Common
{
    public interface IEventSerializer
    {
        string Serialize(object events);
        IEnumerable<Event> Deserialize(string events);
    }
}