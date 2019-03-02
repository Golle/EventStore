namespace StreamingHiddenDonut.DataSources.MSSQL.Database
{
    internal interface ISqlCommand
    {
        string SqlQuery { get; }
    }
}