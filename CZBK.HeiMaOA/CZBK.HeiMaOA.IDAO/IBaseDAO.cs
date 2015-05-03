using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.IDAO
{
    public interface IBaseDAO<T> where T : class,new()
    {
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadEntities<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderbyLambda, bool isAsc);
        IQueryable<T> LoadPageEntities<TKey>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderbyLambda, bool isAsc);
        T FindEntity(object id);
        T DeleteEntity(T entity);
        T UpdateEntity(T entity);
        T AddEntity(T entity);
    }
}
