using DLiteAuthFrame.APP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.IApp
{
    public interface IRoleManageApp
    {
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        ResultModel AddRole(RoleViewModel Info);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        ResultModel UpdateRole(RoleViewModel Info);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        ResultModel DeleteRole(Guid ID);

        /// <summary>
        /// 角色授权
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Auths"></param>
        /// <returns></returns>
        ResultModel RoleSetAuth(Guid ID, List<Guid> Auths);
    }
}
