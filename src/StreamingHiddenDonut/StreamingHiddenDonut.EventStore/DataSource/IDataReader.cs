using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.DataSource
{
    public interface IDataReader
    {
        Task<IEnumerable<Commit>> Read(Guid streamId);
    }
}