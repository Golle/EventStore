using StreamingHiddenDonut.Core.DataSources;

namespace StreamingHiddenDonut.DataSources.MSSQL
{
    public class MsSqlDataSourceOptions : IDataSourceOptions
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