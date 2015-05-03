using CZBK.HeiMaOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.DAOFACTORY
{
    public class DBContextFactory
    {
        public static DbContext CreateDbContext()
        {
            //CallContext数据槽保证EF上下文唯一
            DbContext context = (DbContext)CallContext.GetData("context");
            if (context == null)
            {
                context = new DBContext();
                CallContext.SetData("context", context);
            }
            return context;
        }
    }
}
