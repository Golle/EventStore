using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.DataSource;

namespace StreamingHiddenDonut.EventStore
{
    public interface IEventStoreBuilder
    {
        IEventStoreBuilder WithDataSource(IDataSourceInitializer dataSourceInitializer);
        Task Initialize();
    }
}
