using System.Data;

namespace Cototal.Dapper.Shared.Standard
{
    public interface IConnectionFactory
    {
        IDbConnection Get();
    }
}
