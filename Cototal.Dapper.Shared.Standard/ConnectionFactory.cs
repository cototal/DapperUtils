using System.Data;
using System.Data.SqlClient;

namespace Cototal.Dapper.Shared.N4
{
    /// <summary>
    /// Basic implementation of the connection factory. I believe being dependent on
    /// 'SqlClient' makes it specific to SQL Server databases.
    /// </summary>
    class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Get()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
