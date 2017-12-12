using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DLiteAuthFrame.Domain.IServices.IAuthservices
{
    public  interface IUserService
    {
        void Add(User user);

        void Delete(User user);

        void Update(User user);

        User GetUser(Guid ID);

        string CheckPassWord(string Name,string PassWord);

        IQueryable<User> GetUsers(Expression<Func<User, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        /// 获取指定用户菜单权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<Menu> GetMenu(Guid UserID);

        /// <summary>
        /// 获取机构
        /// </summary>
        /// <returns></returns>
        IQueryable<Organization> GetOrg(Guid UserID);

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        IQueryable<Role> GetRole(Guid UserID);

        /// <summary>
        /// 设置机构
        /// </summary>
        /// <returns></returns>
        void SetOrg(Guid UserID,List<Guid> Orgs);

        /// <summary>
        /// 设置角色
        /// </summary>
        /// <param name="Roles"></param>
        /// <returns></returns>
        void SetRole(Guid UserID, List<Guid> Roles);             

    }
}
