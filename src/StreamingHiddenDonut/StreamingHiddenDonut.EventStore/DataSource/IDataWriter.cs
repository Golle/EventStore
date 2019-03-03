using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.DataSource
{
    public interface IDataWriter
    {
        Task Append(Commit commit);
    }
}
