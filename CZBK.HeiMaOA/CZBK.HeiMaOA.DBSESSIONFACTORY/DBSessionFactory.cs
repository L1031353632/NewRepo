using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CZBK.HeiMaOA.IDBSESSION;
using CZBK.HeiMaOA.DBSESSION;

namespace CZBK.HeiMaOA.DBSESSIONFACTORY
{
    /// <summary>
    /// 通过数据槽保证数据上下文唯一，创建回话类
    /// </summary>
    public class DBSessionFactory
    {
        public static IDBSession CreateDBSession()
        {
            //通过数据槽保证数据上下文唯一
            IDBSession session = (IDBSession)CallContext.GetData("session");
            if (session == null)
            {
                session = new DBSession();
                CallContext.SetData("session", session);
            }
            return session;
        }
    }
}
