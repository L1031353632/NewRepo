using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.HeiMaOA.IDAO;
using CZBK.HeiMaOA.IDBSESSION;

namespace CZBK.HeiMaOA.IBLL
{
    public interface IBaseManager<T> where T : class,new()
    {
        IDBSession DBSessionContext { get; }
        IBaseDAO<T> CurrentDAO { get; set; }
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadEntities<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderbyLambda, bool isAsc);
        IQueryable<T> LoadPageEntities<TKey>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderbyLambda, bool isAsc);
        T FindEntity(object id);
        bool DeleteEntity(T entity);
        bool UpdateEntity(T entity);
        bool AddEntity(T entity);
    }
}
