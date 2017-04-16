using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cototal.Dapper.Shared.N4
{
    /// <summary>
    /// Used to consistently pass connection options between repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConnectionOptions<T>
        where T : class
    {
        public ConnectionOptions()
        {

        }

        public ConnectionOptions(T model, IDbConnection conn = null, IDbTransaction trans = null)
        {
            Model = model;
            Connection = conn;
            Transaction = trans;
        }

        public T Model { get; set; }
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
    }
}
