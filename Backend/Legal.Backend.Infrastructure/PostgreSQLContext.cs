using System.Data;
using Npgsql;

namespace Legal.Backend.Infrastructure
{
    public class PostgreSQLContext
    {
        private readonly string _connectionString;

        public PostgreSQLContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}