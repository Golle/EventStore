using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.Core;
using StreamingHiddenDonut.Core.DataSources;

namespace StreamingHiddenDonut.DataSources.MSSQL
{
    public class MsSqlDataSourceInitializer : IDataSourceInitializer
    {
        public MsSqlDataSourceInitializer(MsSqlDataSourceOptions options)
        {
        }
        public Task Initialize()
        {
            Console.WriteLine("Created the awesome Database");
            return Task.CompletedTask;
        }
    }

    public class MsSqlDataSourceOptions : IDataSourceOptions
    {
        private readonly string _connectionString;
        private readonly string _table;
        private readonly bool _createOnInit;

        public MsSqlDataSourceOptions(string connectionString, string table = "eventstore", bool createOnInit = false)
        {
            _connectionString = connectionString;
            _table = table;
            _createOnInit = createOnInit;
        }
    }

    public static class EventStoreBuilderExtensions
    {
        public static IEventStoreBuilder WithMsSql(this IEventStoreBuilder builder, MsSqlDataSourceOptions options)
        {
            return builder.WithDataSource(new MsSqlDataSourceInitializer(options));
        }
    }
}
