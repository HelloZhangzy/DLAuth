using DLiteAuthFrame.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Linq.Expressions;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Base.Model;
using System.Data.Entity;
using EntityFramework.Extensions;
using System.Text.RegularExpressions;

namespace DLiteAuthFrame.Base.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //protected DbContext Context;
        protected DbContext Context = null;
        //是否独享
        public bool isExclusive { get; set; }

        //public Repository()
        //{
        //    Context = new DLAuthContext();
        //    isExclusive = true;
        //}

        public Repository(DbContext context)
        {
            this.Context = context;
            isExclusive = true;
        }

        protected DbSet<T> DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public void Dispose()
        {
            if(isExclusive) Context.Dispose();
        }

        public virtual IQueryable<T> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<T>();
        }
        
        public IQueryable<T> Filter(Expression<Func<T, bool>> filter,out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? DbSet.Where(filter).AsQueryable() :  DbSet.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public virtual T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual T Create(T TObject)
        {
            var newEntry = DbSet.Add(TObject);
            if (isExclusive) Context.SaveChanges();
            return newEntry;
        }

        public virtual int Count
        {
            get
            {
                return DbSet.Count();
            }
        }

        public virtual void Delete(T TObject)
        {
            DbSet.Remove(TObject);
            if (isExclusive)
                Context.SaveChanges();
            //if (!shareContext)
            //    return Context.SaveChanges();
            //return 0;
        }
              
        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            if (isExclusive)
                return Context.SaveChanges();
            return 0;
        }

        public virtual int Update(T TObject)
        {
            var entry = Context.Entry(TObject);
            DbSet.Attach(TObject);
            entry.State = EntityState.Modified;
            if (isExclusive)
                return Context.SaveChanges();
            return 0;
        }
    }

    public class Repository2<TEntity> : IRepository2<TEntity> where TEntity : class, new()
    {
       // public DLAuthContext dbcontext = new DLAuthContext();

        private readonly DbContext _dbContext;       

        protected Repository2(DbContext context)
        {
            if (context != null) this._dbContext = context;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);           
        }

        public void Add(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);           
        }

        public void Update(TEntity entity)
        {
            var entry = this._dbContext.Entry(entity);           
            entry.State = EntityState.Modified;     
        }      

        public void Update(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> entity)
        {
            _dbContext.Set<TEntity>().Where(where).Update(entity);
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);           
        }

        public void Delete(Expression<Func<TEntity, bool>> exp)
        {
            var entitys = _dbContext.Set<TEntity>().Where(exp).ToList();
            entitys.ForEach(m => _dbContext.Entry<TEntity>(m).State = EntityState.Deleted);
        }

        private IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> exp)
        {
            var dbSet = _dbContext.Set<TEntity>().AsQueryable();
            if (exp != null) dbSet = dbSet.Where(exp);
            return dbSet;
        }


        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> exp = null)
        {
            return Filter(exp);           
        }

        public IQueryable<TEntity> Find(int pageindex = 1, int pagesize = 10, string orderby = "", Expression<Func<TEntity, bool>> exp = null)
        {
            if(pageindex < 1) pageindex = 1;           

            //return Filter(exp).OrderBy(orderby).Skip(pagesize * (pageindex - 1)).Take(pagesize);
            string[] _order = orderby.Split(',');

            MethodCallExpression resultExp = null;
            var tempData = _dbContext.Set<TEntity>().AsQueryable();
            foreach (string item in _order)
            {              
                string[] _orderArry = item.Split(' ');
                string _orderField = _orderArry[0];
                bool isAsc=true;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(TEntity), "t");
                var property = typeof(TEntity).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }

            tempData = Filter(exp).Provider.CreateQuery<TEntity>(resultExp);

            return tempData.Skip(pagesize * (pageindex - 1)).Take(pagesize);
        }

        public TEntity FindTEntity(Expression<Func<TEntity, bool>> exp = null)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(exp);
        }

        public int GetCount(Expression<Func<TEntity, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        public bool IsExist(Expression<Func<TEntity, bool>> exp)
        {
            return _dbContext.Set<TEntity>().Any(exp);
        }

        
    }
}
