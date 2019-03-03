using System;
using System.Threading.Tasks;
using StreamingHiddenDonut.EventStore;
using StreamingHiddenDonut.EventStore.Iniitializer;
using StreamingHiddenDonut.EventStore.MSSQL;
using StreamingHiddenDonut.EventStore.Serializers;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace EventStreamSample1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var eventStore = await EventStoreInitializer.CreateEventStore("My event store")
                .WithMsSql(new MsSqlDataSourceOptions(@"Server=(LocalDb)\MSSQLLocalDB;Database=eventstore_1;Integrated Security=true;", table: "eventstore1", createOnInit: true))
                .WithEventSerializer(new JsonEventSerializer())
                .Build();

            await Sample1(eventStore);

            Console.ReadKey();
        }

        private static async Task Sample1(IEventStore eventStore)
        {
            var streamId = Guid.NewGuid();
            //var streamId = Guid.Parse("150B17B7-EF36-449B-BC48-DCC10EC985F9");
            

            var writer = eventStore.Writer;
            var reader = eventStore.Reader;

            
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
