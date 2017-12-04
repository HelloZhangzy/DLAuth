using DLiteAuthFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DLiteAuthFrame.Domain.IRepository
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepository2<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        TEntity FindTEntity(Expression<Func<TEntity, bool>> exp = null);
        /// <summary>
        /// 查询实体是否存在
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<TEntity, bool>> exp);
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> exp = null);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="orderby"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        IQueryable<TEntity> Find(int pageindex = 1, int pagesize = 10, string orderby = "", Expression<Func<TEntity, bool>> exp = null);
        /// <summary>
        /// 获取实体个数
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        int GetCount(Expression<Func<TEntity, bool>> exp = null);

        /// <summary>
        /// 单实体增加
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="entities"></param>
        void Add(List<TEntity> entities);

        /// <summary>
        /// 更新单实体的所有属性
        /// </summary>
        void Update(TEntity entity);
        
        /// <summary>
        /// 实现按需要只更新部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        void Update(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> entity);

        void Delete(TEntity entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        void Delete(Expression<Func<TEntity, bool>> exp);
        
    }

    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        IQueryable<T> All();

        /// <summary>
        /// 根据条件获取数据
        /// </summary>
        /// <param name="predicate">Specified a filter</param>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据条件和分页信息获取数据
        /// </summary>         
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        /// 根据条件查年数据是否存在
        /// </summary>       
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find object by keys.
        /// </summary>
        T Find(params object[] keys);

        /// <summary>
        /// 根据条件查找对象
        /// </summary>
        /// <param name="predicate"></param>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///新增
        /// </summary>        
        T Create(T t);

        /// <summary>
        /// 删除
        /// </summary>       
        void Delete(T t);

        /// <summary>
        /// 根据条件指删除
        /// </summary>       
        int Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 修改数据
        /// </summary>       
        int Update(T t);

        /// <summary>
        /// 获取对象数量
        /// </summary>
        int Count { get; }
    }
}
