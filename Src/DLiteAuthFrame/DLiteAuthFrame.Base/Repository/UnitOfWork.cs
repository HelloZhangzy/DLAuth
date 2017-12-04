using Autofac;
using DLiteAuthFrame.Base.AutoFac;
using DLiteAuthFrame.Base.Model;
using DLiteAuthFrame.Domain.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLiteAuthFrame.Domain.IRepository;

namespace DLiteAuthFrame.Base.Repository
{
    /// <summary>
    /// 工作单元
    /// 封装仓储，封闭事务
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _dbContext { get; set; }

        private DbContextTransaction _dbTransaction;
        private bool IsTransaction = false;

        public UnitOfWork(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _dbTransaction = _dbContext.Database.BeginTransaction();
            IsTransaction = true;
        }

        public bool Commit()
        {
            _dbContext.SaveChanges();
            if (IsTransaction)
            {
                _dbTransaction.Commit();
            }            
            return true;          
        }

        public void Rollback()
        {
            _dbTransaction.Rollback();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeName = typeof(T).Name; 
            
            var repositoryInstance = AutofacExt.Resolve<IRepository<T>>(new NamedParameter("context", _dbContext));

            return repositoryInstance;
        }
            
    }
}
