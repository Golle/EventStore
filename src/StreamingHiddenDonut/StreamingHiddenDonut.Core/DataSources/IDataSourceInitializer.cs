using System.Threading.Tasks;

namespace StreamingHiddenDonut.Core.DataSources
{
    public interface IDataSourceInitializer
    {
        Task Initialize();
    }

    public interface IDataSourceOptions
    {
    }
}
