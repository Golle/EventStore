using StreamingHiddenDonut.EventStore.MSSQL.Database.Connection;

namespace StreamingHiddenDonut.EventStore.MSSQL
{
    public static class EventStoreBuilderExtensions
    {
        public static IEventStoreBuilder WithMsSql(this IEventStoreBuilder builder, MsSqlDataSourceOptions options)
        {
            return builder.WithDataSource(new MsSqlDataSourceInitializer(options, new SqlConnectionFactory()));
        }
    }
}