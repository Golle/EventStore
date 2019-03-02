using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.DataSources.MSSQL.Database.Connection.Reader;

namespace StreamingHiddenDonut.DataSources.MSSQL.Database.Connection
{
    internal interface ISqlConnection : IDisposable
    {
        Task Open();
        Task<ISqlDataReader> Query(ISqlQuery query);
        Task<int> Command(ISqlCommand command);
        Task Close();
    }
}
