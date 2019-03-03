using System;
using System.Threading.Tasks;

namespace StreamingHiddenDonut.EventStore.MSSQL.Database.Connection.Reader
{
    internal interface ISqlDataReader
    {
        Task<bool> ReadNext();
        string ReadString(int column);
        Guid ReadGuid(int column);
        long GetLong(int column);
    }
}