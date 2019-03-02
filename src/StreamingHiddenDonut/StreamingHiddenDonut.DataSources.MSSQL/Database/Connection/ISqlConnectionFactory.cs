namespace StreamingHiddenDonut.DataSources.MSSQL.Database.Connection
{
    internal interface ISqlConnectionFactory
    {
        ISqlConnection CreateConnection(string connectionString);
    }
}