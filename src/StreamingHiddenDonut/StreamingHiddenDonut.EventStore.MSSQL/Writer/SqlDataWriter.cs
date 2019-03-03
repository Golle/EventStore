using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.DataSource;
using StreamingHiddenDonut.EventStore.MSSQL.Database;
using StreamingHiddenDonut.EventStore.MSSQL.Database.Connection;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.MSSQL.Writer
{
    internal class SqlDataWriter : IDataWriter
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;
        private readonly MsSqlDataSourceOptions _options;

        public SqlDataWriter(SqlConnectionFactory sqlConnectionFactory, MsSqlDataSourceOptions options)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _options = options;
        }

        public async Task Append(Commit commit)
        {
            using (var connection = _sqlConnectionFactory.CreateConnection(_options.ConnectionString))
            {
                await connection.Open();
                var insertCommitCommand = SqlDataWriterCommands.GetInsertCommitCommand(_options.Table, commit.StreamId, commit.CommitId, commit.Created, commit.Events);
                await connection.Command(new SqlCommand(insertCommitCommand));
                await connection.Close();
            }
        }
    }
}
