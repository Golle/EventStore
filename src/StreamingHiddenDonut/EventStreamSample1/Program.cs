using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore;
using StreamingHiddenDonut.EventStore.Iniitializer;
using StreamingHiddenDonut.EventStore.MSSQL;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace EventStreamSample1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await EventStoreInitializer.CreateEventStore("My event store")
                .WithMsSql(new MsSqlDataSourceOptions(@"Server=(LocalDb)\MSSQLLocalDB;Database=eventstore_1;Integrated Security=true;", table: "eventstore1", createOnInit: true))
                .Initialize();

            Console.ReadKey();
        }

        private static async Task Sample1()
        {
            var streamId = Guid.NewGuid();
            var bs = new Bootstrapper();

            var writer = bs.Writer;
            var reader = bs.Reader;


            await writer.PushToStream(streamId, new UserCreatedEvent {Name = "a", UserId = "user-id: a"});
            await writer.PushToStream(streamId, new UserCreatedEvent {Name = "b", UserId = "user-id: b"});
            await writer.PushToStream(streamId, new UserCreatedEvent {Name = "c", UserId = "user-id: c"});
            await writer.PushToStream(streamId, new UserCreatedEvent {Name = "d", UserId = "user-id: d"});
            await writer.PushToStream(streamId, new UserCreatedEvent {Name = "e", UserId = "user-id: e"});
            await writer.PushToStream(streamId, new UserCreatedEvent {Name = "f", UserId = "user-id: f"});


            var result = await reader.GetStream(streamId);

            foreach (var @event in result)
            {
                Handle((dynamic) @event);
            }

            Console.ReadKey();
        }

        private static void Handle(UserCreatedEvent @event)
        {
            Console.WriteLine($"User '{@event.Name}' with UserId '{@event.UserId}'");
        }
    }


    public class UserCreatedEvent : Event
    {
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
