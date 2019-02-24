using System;
using System.Linq;
using System.Threading.Tasks;

using StreamingHiddenDonut.DataSources.MSSQL;
using StreamingHiddenDonut.EventStore;
using StreamingHiddenDonut.EventStore.Iniitializer;
using StreamingHiddenDonut.EventStore.Stream.Data;

namespace EventStreamSample1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await EventStoreInitializer.CreateEventStore("My event store")
                .WithMsSql(new MsSqlDataSourceOptions("c"))
                .Initialize();

            Console.ReadKey();
        }

        private static async Task Sample1()
        {
            var streamId = Guid.NewGuid();
            var bs = new Bootstrapper();

            var writer = bs.Writer;
            var reader = bs.Reader;


            await writer.PushToStream(streamId, new CreatedUserEvent {Name = "a", UserId = "user-id: a"});
            await writer.PushToStream(streamId, new CreatedUserEvent {Name = "b", UserId = "user-id: b"});
            await writer.PushToStream(streamId, new CreatedUserEvent {Name = "c", UserId = "user-id: c"});
            await writer.PushToStream(streamId, new CreatedUserEvent {Name = "d", UserId = "user-id: d"});
            await writer.PushToStream(streamId, new CreatedUserEvent {Name = "e", UserId = "user-id: e"});
            await writer.PushToStream(streamId, new CreatedUserEvent {Name = "f", UserId = "user-id: f"});


            var result = await reader.GetStream(streamId);

            foreach (var @event in result)
            {
                Handle((dynamic) @event);
            }

            Console.ReadKey();
        }

        private static void Handle(CreatedUserEvent @event)
        {
            Console.WriteLine($"User '{@event.Name}' with UserId '{@event.UserId}'");
        }
    }


    public class CreatedUserEvent : Event
    {
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
