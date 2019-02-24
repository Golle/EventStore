using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.DataSource.InMemory
{
    internal class InMemoryDataReader : IDataReader
    {
        private readonly IInMemoryDataStore _inMemoryDataStore;

        public InMemoryDataReader(IInMemoryDataStore inMemoryDataStore)
        {
            _inMemoryDataStore = inMemoryDataStore;
        }
        public async Task<IEnumerable<Commit>> Read(Guid streamId)
        {
            var result = new List<Commit>(_inMemoryDataStore.GetCommits(streamId));
            return await Task.FromResult(result);
        }
    }
}