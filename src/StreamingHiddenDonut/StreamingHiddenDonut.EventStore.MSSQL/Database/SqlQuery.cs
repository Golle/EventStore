namespace StreamingHiddenDonut.EventStore.MSSQL.Database
{
    internal class SqlQuery : ISqlQuery
    {
        public string Query { get; }

        public SqlQuery(string query)
        {
            Query = query;
        }
    }
}