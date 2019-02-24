using System;

namespace StreamingHiddenDonut.EventStore.Common
{
    internal interface IDataTime
    {
        DateTime Now { get; }
    }
}