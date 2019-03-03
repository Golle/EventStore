using System;

namespace StreamingHiddenDonut.EventStore.MSSQL.Writer
{
    internal class SqlDataWriterCommands
    {
        private const string InsertCommitSql = @"INSERT INTO [{0}]([stream_id], [commit_id], [created], [events]) VALUES('{1}', '{2}', '{3}', '{4}');";

        internal static string GetInsertCommitCommand(string tableName, Guid streamId, Guid commitId, DateTime created, string events)
        {
            return string.Format(InsertCommitSql, tableName, streamId, commitId, created, events);
        }
    }
}