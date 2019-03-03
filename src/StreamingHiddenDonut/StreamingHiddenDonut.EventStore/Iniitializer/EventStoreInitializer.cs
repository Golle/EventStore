namespace StreamingHiddenDonut.EventStore.Iniitializer
{
    public static class EventStoreInitializer
    {
        public static IEventStoreBuilder CreateEventStore(string eventStoreName)
        {
            return new EventStoreBuilder(eventStoreName);
        }
    }
}