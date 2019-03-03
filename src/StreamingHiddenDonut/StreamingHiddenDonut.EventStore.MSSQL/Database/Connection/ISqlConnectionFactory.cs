namespace StreamingHiddenDonut.EventStore.MSSQL.Database.Connection
{
    internal interface ISqlConnectionFactory
    {
        ISqlConnection CreateConnection(string connectionString);
    }
}