using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Domain.IRepository
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        bool Commit();

        void Rollback();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
