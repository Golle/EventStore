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
                    CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ([stream_id] ASC)
                        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	            END";

        internal static string GetCreateEventStoreSql(string tableName)
        {
            return string.Format(CreateEventStore, tableName);
        }
    }
}