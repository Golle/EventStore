using System;
using System.Collections.Generic;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.DataSource.InMemory
{
    internal interface IInMemoryDataStore
    {
        IEnumerable<Commit> GetCommits(Guid streamId);
        void WriteCommit(Commit commit);
    }
}