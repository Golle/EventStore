using System.Threading.Tasks;

namespace StreamingHiddenDonut.EventStore.DataSource
{
    public interface IDataSourceInitializer
    {
        Task Initialize();
    }
}
