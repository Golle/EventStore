namespace StreamingHiddenDonut.EventStore.MSSQL.Initializer
{
    internal static class DatabaseQueries
    {
        private const string CreateEventStore =
            @"IF NOT EXISTS(SELECT * FROM sys.tables WHERE name = '{0}')
                BEGIN
                    CREATE TABLE [{0}] (
	                    [stream_id] [uniqueidentifier] NOT NULL,
	                    [commit_id] [uniqueidentifier] NOT NULL,
	                    [sequence_number] [bigint] IDENTITY(1,1) NOT NULL,
	                    [created] [datetime] NOT NULL,
	                    [events] [nvarchar](max) NOT NULL,
                        INDEX [IX_stream_id] NONCLUSTERED ([stream_id])
                    )   
	            END";

        internal static string GetCreateEventStoreSql(string tableName)
        {
            return string.Format(CreateEventStore, tableName);
        }
    }
}