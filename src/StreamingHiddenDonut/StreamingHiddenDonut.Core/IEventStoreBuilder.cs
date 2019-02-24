using System.Threading.Tasks;
using StreamingHiddenDonut.Core.DataSources;

namespace StreamingHiddenDonut.Core
{
    public interface IEventStoreBuilder
    {
        IEventStoreBuilder WithDataSource(IDataSourceInitializer dataSourceInitializer);
        Task Initialize();
    }
}
