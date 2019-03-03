using System.Data.SqlClient;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.MSSQL.Database.Connection.Reader;

namespace StreamingHiddenDonut.EventStore.MSSQL.Database.Connection
{
    internal class SqlConnectionWrapper : ISqlConnection
    {
        private readonly SqlConnection _connection;

        public SqlConnectionWrapper(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<ISqlDataReader> Query(ISqlQuery query)
        {
            var sqlCommand = new System.Data.SqlClient.SqlCommand(query.SqlQuery, _connection);
            return new SqlDataReaderWrapper(await sqlCommand.ExecuteReaderAsync());
        }

        public async Task<int> Command(ISqlCommand command)
        {
            var sqlCommand = new System.Data.SqlClient.SqlCommand(command.SqlQuery, _connection);
            return await sqlCommand.ExecuteNonQueryAsync();
        }

        public Task Open()
        {
            return _connection.OpenAsync();
        }

        public Task Close()
        {
            _connection.Close();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}