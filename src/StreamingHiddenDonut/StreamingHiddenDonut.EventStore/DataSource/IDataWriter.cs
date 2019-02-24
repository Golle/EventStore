using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.DataSource
{
    internal interface IDataWriter
    {
        Task Append(Commit commit);
    }
}
