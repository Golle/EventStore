using System.Data.SqlClient;

namespace StreamingHiddenDonut.DataSources.MSSQL.Database.Connection
{
    internal class SqlConnectionFactory : ISqlConnectionFactory
    {
        public ISqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnectionWrapper(new SqlConnection(connectionString));
        }
    }
}