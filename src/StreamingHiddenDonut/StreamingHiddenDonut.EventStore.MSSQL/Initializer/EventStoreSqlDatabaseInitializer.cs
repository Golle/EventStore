using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.MSSQL.Database;
using StreamingHiddenDonut.EventStore.MSSQL.Database.Connection;

namespace StreamingHiddenDonut.EventStore.MSSQL.Initializer
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
