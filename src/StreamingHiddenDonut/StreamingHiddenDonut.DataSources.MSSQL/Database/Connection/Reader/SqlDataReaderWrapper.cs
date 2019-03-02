using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StreamingHiddenDonut.DataSources.MSSQL.Database.Connection.Reader
{
    internal class SqlDataReaderWrapper : ISqlDataReader
    {
        private readonly SqlDataReader _reader;

        public SqlDataReaderWrapper(SqlDataReader reader)
        {
            _reader = reader;
        }

        public async Task<bool> ReadNext()
        {   
            return await _reader.ReadAsync();
        }
    }
}