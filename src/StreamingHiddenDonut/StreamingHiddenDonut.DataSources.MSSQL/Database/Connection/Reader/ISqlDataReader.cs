using System.Threading.Tasks;

namespace StreamingHiddenDonut.DataSources.MSSQL.Database.Connection.Reader
{
    internal interface ISqlDataReader
    {
        Task<bool> ReadNext();
    }
}