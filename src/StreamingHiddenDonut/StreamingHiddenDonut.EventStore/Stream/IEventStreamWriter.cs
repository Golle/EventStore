using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.Stream
{
    public interface IEventStreamWriter
    {
        Task PushToStream(Guid streamId, params Event[] events);
    }
}