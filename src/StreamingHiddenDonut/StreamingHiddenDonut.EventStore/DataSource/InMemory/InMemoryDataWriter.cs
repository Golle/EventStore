using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.DataSource.InMemory
{
    internal class InMemoryDataWriter : IDataWriter
    {
        private readonly IInMemoryDataStore _inMemoryDataStore;

        public InMemoryDataWriter(IInMemoryDataStore inMemoryDataStore)
        {
            _inMemoryDataStore = inMemoryDataStore;
        }
        public Task Append(Commit commit)
        {
            _inMemoryDataStore.WriteCommit(commit);
            return Task.CompletedTask;
        }
    }
}