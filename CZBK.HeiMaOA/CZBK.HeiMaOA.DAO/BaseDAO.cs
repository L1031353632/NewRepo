using CZBK.HeiMaOA.DAOFACTORY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.DAO
{
    public class BaseDAO<T> where T : class,new()
    {
        /// <summary>
        /// EF上下文 
        /// </summary>
        DbContext context = DBContextFactory.CreateDbContext();//完成EF上下文创建.

        /// <summary>
        /// 基本查询方法
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return context.Set<T>().Where<T>(whereLambda);
        }

        /// <summary>
        /// 带排序查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderbyLambda">排序字段</param>
        /// <param name="isAsc">升序（true）</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderbyLambda, bool isAsc)
        {
            IQueryable<T> temp = null;
            if (isAsc)
            {
                return temp = context.Set<T>().Where<T>(whereLambda).OrderBy<T, TKey>(orderbyLambda);
            }
            else
            {
                return temp = context.Set<T>().Where<T>(whereLambda).OrderByDescending<T, TKey>(orderbyLambda);
            }

        }

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="TKey">排序的约束</typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="whereLambda">过滤条件</param>
        /// <param name="orderbyLambda">排序条件</param>
        /// <param name="isAsc">排序方式</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<TKey>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderbyLambda, bool isAsc)
        {
            var temp = context.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)//如果成立表示升序
            {
                temp = temp.OrderBy<T, TKey>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, TKey>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;

        }

        /// <summary>
        /// 根据主键查找数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public T FindEntity(object id)
        {
            return context.Set<T>().Find(id);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T DeleteEntity(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Deleted;
            return entity;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T UpdateEntity(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }
    }
}
