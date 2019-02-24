using System;

namespace StreamingHiddenDonut.EventStore.Common
{
    internal class DataTimeWrapper : IDataTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}