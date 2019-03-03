namespace StreamingHiddenDonut.EventStore.MSSQL.Database
{
    internal interface ISqlCommand
    {
        string SqlQuery { get; }
    }
}