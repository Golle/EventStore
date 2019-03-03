using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Common;
using StreamingHiddenDonut.EventStore.DataSource;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.Stream
{
    internal class EventStreamReader : IEventStreamReader
    {
        private readonly DataSource.IDataReader _dataReader;
        private readonly IEventSerializer _eventSerializer;

        public EventStreamReader(DataSource.IDataReader dataReader, IEventSerializer eventSerializer)
        {
            _dataReader = dataReader;
            _eventSerializer = eventSerializer;
        }

        public async Task<IEnumerable<Event>> GetStream(Guid streamId)
        {
            return (await _dataReader.Read(streamId)).SelectMany(commit => _eventSerializer.Deserialize(commit.Events));
        }

        public Task<IEnumerable<Event>> GetStream(Guid streamId, int fromSequenceNumber)
        {
            throw new NotImplementedException();
        }
    }
}