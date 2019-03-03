using System.Threading.Tasks;

namespace StreamingHiddenDonut.EventStore.MSSQL.Database.Connection.Reader
{
    internal interface ISqlDataReader
    {
        Task<bool> ReadNext();
    }
}