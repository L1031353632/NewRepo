using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.HeiMaOA.DAOFACTORY;
using CZBK.HeiMaOA.IDAO;
using CZBK.HeiMaOA.IDBSESSION;

namespace CZBK.HeiMaOA.DBSESSION
{
    /// <summary>
    /// 回话层
    /// </summary>
    public partial class DBSession : IDBSession
    {
        private IWorkerDAO _WorkerDAO;
        public IWorkerDAO WorkerDAO
        {
            get
            {
                if (_WorkerDAO == null)
                {
                    _WorkerDAO = DAOAbstractFactory.CreateWorkerDAO();
                }
                return _WorkerDAO;
            }
            set { _WorkerDAO = value; }
        }


        /// <summary>
        /// 数据上下文
        /// </summary>
        public DbContext dbContext
        {
            get
            {
                //完成EF上下文创建
                return DBContextFactory.CreateDbContext();
            }
        }

        /// <summary>
        /// 统一提交数据库
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
