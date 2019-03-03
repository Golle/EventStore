using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.DataSource;
using StreamingHiddenDonut.EventStore.MSSQL.Database.Connection;
using StreamingHiddenDonut.EventStore.MSSQL.Initializer;

namespace StreamingHiddenDonut.EventStore.MSSQL
{
    internal class MsSqlDataSourceInitializer : IDataSourceInitializer
    {
        private readonly MsSqlDataSourceOptions _options;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public MsSqlDataSourceInitializer(MsSqlDataSourceOptions options, ISqlConnectionFactory sqlConnectionFactory)
        {
            _options = options;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task Initialize()
        {
            if (!_options.CreateOnInit)
            {
                return;
            }

            using (var connection = _sqlConnectionFactory.CreateConnection(_options.ConnectionString))
            {
                try
                {
                    await connection.Open();
                    await new EventStoreSqlDatabaseInitializer(connection)
                        .CreateTableIfNotExists(_options.Table);
                    await connection.Close();
                }
                catch (Exception e)
                {
                    await Console.Error.WriteLineAsync($"{GetType().Name} failed with exception: {e.Message}");
                    throw;
                }
            }
        }
    }
}
