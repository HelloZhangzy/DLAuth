using DLiteAuthFrame.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Base.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        bool Commit();

        void Rollback();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
