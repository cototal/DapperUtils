using System.Data;

namespace Cototal.Dapper.Shared.N4
{
    public interface IConnectionFactory
    {
        IDbConnection Get();
    }
}
