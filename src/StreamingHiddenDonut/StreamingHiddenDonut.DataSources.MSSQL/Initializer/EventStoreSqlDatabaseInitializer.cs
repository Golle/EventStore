using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.DataSources.MSSQL.Database;
using StreamingHiddenDonut.DataSources.MSSQL.Database.Connection;

namespace StreamingHiddenDonut.DataSources.MSSQL.Initializer
{
    internal class EventStoreSqlDatabaseInitializer
    {
        private readonly ISqlConnection _sqlConnection;

        public EventStoreSqlDatabaseInitializer(ISqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task CreateTableIfNotExists(string tableName)
        {
            await _sqlConnection.Command(new SqlCommand(DatabaseQueries.GetCreateEventStoreSql(tableName)));
        }
    }
}
