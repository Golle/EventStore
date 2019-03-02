using StreamingHiddenDonut.Core;
using StreamingHiddenDonut.DataSources.MSSQL.Database.Connection;

namespace StreamingHiddenDonut.DataSources.MSSQL
{
    public static class EventStoreBuilderExtensions
    {
        public static IEventStoreBuilder WithMsSql(this IEventStoreBuilder builder, MsSqlDataSourceOptions options)
        {
            return builder.WithDataSource(new MsSqlDataSourceInitializer(options, new SqlConnectionFactory()));
        }
    }
}