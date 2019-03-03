using System.Data.SqlClient;

namespace StreamingHiddenDonut.EventStore.MSSQL.Database.Connection
{
    internal class SqlConnectionFactory : ISqlConnectionFactory
    {
        public ISqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnectionWrapper(new SqlConnection(connectionString));
        }
    }
}