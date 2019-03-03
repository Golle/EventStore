using StreamingHiddenDonut.EventStore.DataSource;
using StreamingHiddenDonut.EventStore.Stream;

namespace StreamingHiddenDonut.EventStore
{
    public interface IEventStore
    {
        IEventStreamWriter Writer { get; }
        IEventStreamReader Reader { get; }
    }
}