using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.Stream
{
    public interface IEventStreamReader
    {
        Task<IEnumerable<Event>> GetStream(Guid streamId);
        Task<IEnumerable<Event>> GetStream(Guid streamId, int fromSequenceNumber);
    }
}