using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.DataSource.InMemory
{
    internal class InMemoryDataStore : IInMemoryDataStore
    {
        private readonly IDictionary<Guid, List<Commit>> _commits = new ConcurrentDictionary<Guid, List<Commit>>();

        public IEnumerable<Commit> GetCommits(Guid streamId)
        {
            return _commits.TryGetValue(streamId, out var commit) ? commit : Enumerable.Empty<Commit>();
        }

        public void WriteCommit(Commit commit)
        {
            lock (_commits)
            {
                if (_commits.TryGetValue(commit.StreamId, out var commitList))
                {
                    commitList.Add(commit);
                }
                else
                {
                    _commits.Add(commit.StreamId, new List<Commit>{commit});
                }
            }
        }
    }
}