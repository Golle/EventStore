using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.DataSource;

namespace StreamingHiddenDonut.EventStore
{
    public class EventStoreBuilder : IEventStoreBuilder
    {
        private readonly string _name;
        private IDataSourceInitializer _dataSource;

        public EventStoreBuilder(string name)
        {
            _name = name;
        }

        public IEventStoreBuilder WithDataSource(IDataSourceInitializer dataSourceInitializer)
        {
            _dataSource = dataSourceInitializer;
            return this;
        }

        public async Task Initialize()
        {
            if (_dataSource == null)
            {
                throw new InvalidOperationException($"DataSource has not been specified. Use UseDataSource<IDataSourceInitializer>() to specify a data source.");
            }
            await _dataSource.Initialize();
        }
    }
}