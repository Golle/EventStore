namespace StreamingHiddenDonut.EventStore.MSSQL
{
    public class MsSqlDataSourceOptions
    {
        public string ConnectionString { get; }
        public string Table { get; }
        public bool CreateOnInit { get; }

        public MsSqlDataSourceOptions(string connectionString, string table = "eventstore", bool createOnInit = false)
        {
            ConnectionString = connectionString;
            Table = table;
            CreateOnInit = createOnInit;
        }
    }
}