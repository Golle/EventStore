using System;

namespace StreamingHiddenDonut.EventStore.MSSQL.Reader
{
    internal static class SqlStreamDataReaderQueries
    {
        private const string EventStreamSql = @"SELECT [commit_id], [sequence_number], [events] FROM [{0}] where [stream_id] = '{1}' ORDER BY [sequence_number]";

        internal static string GetEventStreamQuery(string tableName, Guid streamId)
        {
            return string.Format(EventStreamSql, tableName, streamId);
        }
    }
}