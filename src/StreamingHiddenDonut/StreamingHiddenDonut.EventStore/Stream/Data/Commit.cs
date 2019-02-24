using System;

namespace StreamingHiddenDonut.EventStore.Stream.Data
{
    public class Commit
    {
        public Guid StreamId { get; set; }
        public Guid CommitId { get; set; } // might be database only
        public long SequenceNumber { get; set; } // might be database only
        public DateTime Created { get; set; }
        public string Events { get; set; } // serialized events
    }
}