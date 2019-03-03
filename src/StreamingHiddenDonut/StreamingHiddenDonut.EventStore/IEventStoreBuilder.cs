using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Common;
using StreamingHiddenDonut.EventStore.DataSource;

namespace StreamingHiddenDonut.EventStore
{
    public interface IEventStoreBuilder
    {
        IEventStoreBuilder WithDataSource(IDataSourceInitializer dataSourceInitializer);
        IEventStoreBuilder WithWriter(IDataWriter writer);
        IEventStoreBuilder WithReader(IDataReader reader);
        IEventStoreBuilder WithEventSerializer(IEventSerializer eventSerializer);
        Task<IEventStore> Build();
    }
}
