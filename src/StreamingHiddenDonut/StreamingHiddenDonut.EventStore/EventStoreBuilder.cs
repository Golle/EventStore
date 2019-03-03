using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Common;
using StreamingHiddenDonut.EventStore.DataSource;
using StreamingHiddenDonut.EventStore.Stream;

namespace StreamingHiddenDonut.EventStore
{
    public class EventStoreBuilder : IEventStoreBuilder
    {
        private readonly string _name;
        private IDataSourceInitializer _dataSource;
        private IDataReader _reader;
        private IDataWriter _writer;
        private IEventSerializer _serializer;

        public EventStoreBuilder(string name)
        {
            _name = name;
        }

        public IEventStoreBuilder WithDataSource(IDataSourceInitializer dataSourceInitializer)
        {
            _dataSource = dataSourceInitializer;
            return this;
        }

        public IEventStoreBuilder WithWriter(IDataWriter writer)
        {
            if (_writer != null)
            {
                throw new InvalidOperationException($"Writer with type  {_writer.GetType().Name} has already been registered.");
            }
            _writer = writer;
            return this;
        }

        public IEventStoreBuilder WithReader(IDataReader reader)
        {
            if (_reader != null)
            {
                throw new InvalidOperationException($"Reader with type  {_reader.GetType().Name} has already been registered.");
            }
            _reader = reader;
            return this;
        }

        public IEventStoreBuilder WithEventSerializer(IEventSerializer serializer)
        {
            if (_serializer != null)
            {
                throw new InvalidOperationException($"Serializer with type  {_serializer.GetType().Name} has already been registered.");
            }
            _serializer = serializer;
            return this;
        }

        public async Task<IEventStore> Build()
        {
            Validate();
            await _dataSource.Initialize();

            var dateTime = new DataTimeWrapper();
            var writer = new EventStreamWriter(_writer, _serializer, dateTime);
            var reader = new EventStreamReader(_reader, _serializer);
            return new EventStore(writer, reader);
        }

        private void Validate()
        {
            if (_reader == null)
            {
                throw new InvalidOperationException("No DataReader has been configured");
            }
            if (_writer == null)
            {
                throw new InvalidOperationException("No DataWriter has been configured");
            }
            if (_serializer == null)
            {
                throw new InvalidOperationException("No Serializer has been configured");
            }
            if (_dataSource == null)
            {
                throw new InvalidOperationException($"DataSource has not been specified. Use UseDataSource<IDataSourceInitializer>() to specify a data source.");
            }
        }
    }
}