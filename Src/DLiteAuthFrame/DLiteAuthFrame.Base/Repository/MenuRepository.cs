using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Base.Repository
{
    public class MenuRepository:Repository<Menu>, IMenuRepository
    { 
        public MenuRepository(DbContext db):base(db)
        {

        }
        
    }
}
