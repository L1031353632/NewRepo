using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.HeiMaOA.IDAO;
using CZBK.HeiMaOA.IDBSESSION;
using CZBK.HeiMaOA.DBSESSIONFACTORY;

namespace CZBK.HeiMaOA.BLL
{
    public abstract class BaseManager<T> where T : class,new()
    {
        public BaseManager()
        {
            SetCurrentDAO();
        }
        protected abstract void SetCurrentDAO();
        public IBaseDAO<T> CurrentDAO { get; set; }
        public IDBSession DBSessionContext
        {
            get
            {
                return DBSessionFactory.CreateDBSession();
            }
        }

        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return this.CurrentDAO.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadEntities<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderbyLambda, bool isAsc)
        {
            return this.CurrentDAO.LoadEntities<TKey>(whereLambda, orderbyLambda, isAsc);
        }
        public IQueryable<T> LoadPageEntities<TKey>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderbyLambda, bool isAsc)
        {
            return this.CurrentDAO.LoadPageEntities<TKey>(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }
        public T FindEntity(object id)
        {
            return this.CurrentDAO.FindEntity(id);
        }
        public bool DeleteEntity(T entity)
        {
            this.CurrentDAO.DeleteEntity(entity);
            return this.DBSessionContext.SaveChanges();
        }

        public bool UpdateEntity(T entity)
        {
            this.CurrentDAO.UpdateEntity(entity);
            return this.DBSessionContext.SaveChanges();
        }

        public bool AddEntity(T entity)
        {
            this.CurrentDAO.AddEntity(entity);
            return this.DBSessionContext.SaveChanges();

        }
    }
}
