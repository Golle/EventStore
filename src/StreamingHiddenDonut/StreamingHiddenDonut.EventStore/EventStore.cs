using StreamingHiddenDonut.EventStore.DataSource;
using StreamingHiddenDonut.EventStore.Stream;

namespace StreamingHiddenDonut.EventStore
{
    internal class EventStore : IEventStore
    {
        public IEventStreamWriter Writer { get; }
        public IEventStreamReader Reader { get; }

        public EventStore(IEventStreamWriter writer, IEventStreamReader reader)
        {
            Writer = writer;
            Reader = reader;
        }
    }
}