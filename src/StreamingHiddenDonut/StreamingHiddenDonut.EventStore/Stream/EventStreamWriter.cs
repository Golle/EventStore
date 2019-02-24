using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Common;
using StreamingHiddenDonut.EventStore.DataSource;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.Stream
{
    internal class EventStreamWriter : IEventStreamWriter
    {
        private readonly IDataWriter _dataWriter;
        private readonly IEventSerializer _eventSerializer;
        private readonly IDataTime _dateTime;

        public EventStreamWriter(IDataWriter dataWriter, IEventSerializer eventSerializer, IDataTime dateTime)
        {
            _dataWriter = dataWriter;
            _eventSerializer = eventSerializer;
            _dateTime = dateTime;
        }
        public async Task PushToStream(Guid streamId, params Event[] events)
        {
            var commit = new Commit
            {
                StreamId = streamId,
                CommitId = Guid.NewGuid(),
                Created = _dateTime.Now,
                Events = _eventSerializer.Serialize(events)
            };
            await _dataWriter.Append(commit);
        }
    }
}