using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Domain.IRepository
{
    //用户管理聚合
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 获取用户所属机构信息
        /// </summary>
        /// <returns></returns>
        IQueryable<Organization> GetOrg(Guid id);

        /// <summary>
        /// 获取用户所属角色信息
        /// </summary>
        /// <returns></returns>
        IQueryable<Role> GetRole(Guid id);

        /// <summary>
        /// 获取用户菜单权限
        /// </summary>
        /// <returns></returns>
        IQueryable<Menu> GetMenu(Guid id);

        /// <summary>
        /// 根据机构ID获取用户信息
        /// </summary>
        /// <param name="OrgID"></param>
        /// <returns></returns>
        IQueryable<User> GetUsers(Guid OrgID);


    }
}
