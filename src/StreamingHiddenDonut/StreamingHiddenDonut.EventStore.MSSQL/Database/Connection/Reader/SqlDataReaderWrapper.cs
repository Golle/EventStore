using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StreamingHiddenDonut.EventStore.MSSQL.Database.Connection.Reader
{
    internal class SqlDataReaderWrapper : ISqlDataReader
    {
        private readonly SqlDataReader _reader;

        public SqlDataReaderWrapper(SqlDataReader reader)
        {
            _reader = reader;
        }

        public async Task<bool> ReadNext()
        {   
            return await _reader.ReadAsync();
        }

        public string ReadString(int column)
        {
            EnsureOpen();
            return _reader.GetString(column);
        }

        public Guid ReadGuid(int column)
        {
            EnsureOpen();
            return _reader.GetGuid(column);
        }

        private void EnsureOpen()
        {
            if (_reader.IsClosed)
            {
                throw new InvalidOperationException("Reader is closed");
            }
        }

        public long GetLong(int column)
        {
            EnsureOpen();
            return _reader.GetInt64(column);
        }
    }
}