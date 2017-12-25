using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLiteAuthFrame.Domain.IRepository;
using System.Linq.Expressions;

namespace DLiteAuthFrame.Base.Repository
{
    public class UserRepository :  Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<Menu> GetMenu(Guid id)
        {
            return Context.Set<Menu>();
        }

        public IQueryable<Organization> GetOrg(Guid id)
        {
            return from a in Context.Set<OrgUser>()
                    join b in Context.Set<Organization>() on a.OrgCode equals b.OrgCode
                    where a.UserCode==id
                    select b;
        }

        public IQueryable<Role> GetRole(Guid id)
        {
            return from a in Context.Set<UserRole>()
                   join b in Context.Set<Role>() on a.RoleCode equals b.RoleCode
                   where a.UserCode == id
                   select b;
        }

        /// <summary>
        /// 根据机构ID获取用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IQueryable<User> GetUsers(Guid OrgID)
        {
            return from a in Context.Set<OrgUser>().Where(t => t.OrgCode == OrgID)
                   join b in Context.Set<User>() on a.UserCode equals b.UserCode
                   select b;
        }
    }
}
