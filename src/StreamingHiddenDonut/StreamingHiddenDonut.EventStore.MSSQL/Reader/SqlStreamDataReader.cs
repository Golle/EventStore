using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore.DataSource;
using StreamingHiddenDonut.EventStore.MSSQL.Database;
using StreamingHiddenDonut.EventStore.MSSQL.Database.Connection;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace StreamingHiddenDonut.EventStore.MSSQL.Reader
{
    internal class SqlStreamDataReader : IDataReader
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly MsSqlDataSourceOptions _options;

        public SqlStreamDataReader(ISqlConnectionFactory sqlConnectionFactory, MsSqlDataSourceOptions options)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _options = options;
        }

        public async Task<IEnumerable<Commit>> Read(Guid streamId)
        {
            using (var connection = _sqlConnectionFactory.CreateConnection(_options.ConnectionString))
            {
                await connection.Open();

                var commits = new List<Commit>();
                var result = await connection.Query(new SqlQuery(SqlStreamDataReaderQueries.GetEventStreamQuery(_options.Table, streamId)));
                while (await result.ReadNext())
                {
                    commits.Add(new Commit
                    {
                        CommitId = result.ReadGuid(0),
                        SequenceNumber = result.GetLong(1),
                        Events = result.ReadString(2)
                    });
                }
                await connection.Close();
                return commits;
            }

        }
    }
}