using StreamingHiddenDonut.EventStore.MSSQL.Database.Connection;
using StreamingHiddenDonut.EventStore.MSSQL.Reader;
using StreamingHiddenDonut.EventStore.MSSQL.Writer;

namespace StreamingHiddenDonut.EventStore.MSSQL
{
    public static class EventStoreBuilderExtensions
    {
        public static IEventStoreBuilder WithMsSql(this IEventStoreBuilder builder, MsSqlDataSourceOptions options)
        {
            var sqlConnectionFactory = new SqlConnectionFactory();

            return builder.WithDataSource(new MsSqlDataSourceInitializer(options, sqlConnectionFactory))
                .WithWriter(new SqlDataWriter(sqlConnectionFactory, options))
                .WithReader(new SqlStreamDataReader(sqlConnectionFactory, options));
        }
    }
}