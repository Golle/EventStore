using StreamingHiddenDonut.EventStore.Common;
using StreamingHiddenDonut.EventStore.DataSource.InMemory;
using StreamingHiddenDonut.EventStore.Stream;

namespace StreamingHiddenDonut.EventStore
{
    public class Bootstrapper
    {
        private readonly ServiceCollection _collection;

        public IEventStreamReader Reader => _collection.Reader;
        public IEventStreamWriter Writer => _collection.Writer;
        public Bootstrapper()
        {
            _collection = new ServiceCollection();
        }
    }

    internal class ServiceCollection
    {
        public IEventStreamReader Reader { get; }
        public IEventStreamWriter Writer { get; }

        public ServiceCollection()
        {
            var store = new InMemoryDataStore();
            var reader = new InMemoryDataReader(store);
            var writer = new InMemoryDataWriter(store);
            var serializer = new EventSerializer();
            var dataTimeWrapper = new DataTimeWrapper();
            Reader = new EventStreamReader(reader, serializer);
            Writer = new EventStreamWriter(writer, serializer, dataTimeWrapper);
        }
    }
}
