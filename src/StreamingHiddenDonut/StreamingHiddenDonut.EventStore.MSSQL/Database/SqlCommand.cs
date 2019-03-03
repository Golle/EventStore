namespace StreamingHiddenDonut.EventStore.MSSQL.Database
{
    internal class SqlCommand : ISqlCommand
    {
        public string SqlQuery { get; }
        public SqlCommand(string command)
        {
            SqlQuery = command;
        }
    }
}