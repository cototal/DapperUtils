using System;
using System.Data;

namespace Cototal.Dapper.Shared.N4
{
    /// <summary>
    /// Combine connection and transaction for convenience
    /// </summary>
    public class Contra : IDisposable
    {
        public Contra(IConnectionFactory conn)
        {
            Connection = conn.Get();
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public Contra(IDbConnection db, IDbTransaction trans)
        {
            Connection = db;
            Transaction = trans;
        }

        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }

        public void Dispose()
        {
            Transaction.Dispose();
            Connection.Dispose();
        }
    }
}
