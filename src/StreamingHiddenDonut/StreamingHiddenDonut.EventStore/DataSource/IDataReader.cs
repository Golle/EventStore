using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.DataSource
{
    internal interface IDataReader
    {
        Task<IEnumerable<Commit>> Read(Guid streamId);
    }
}