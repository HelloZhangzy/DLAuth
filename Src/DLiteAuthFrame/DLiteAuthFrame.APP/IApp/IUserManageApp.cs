using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.IApp
{
    public interface IUserManageApp
    {
        /// <summary>
        /// 根据机构ID加载用户
        /// </summary>
        /// <param name="orgID"></param>
        /// <returns></returns>
        List<UserViewModel> GetOrgUsers(Guid orgID);

        /// <summary>
        /// 置换用户状态
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        ResultModel UpdateState(Guid UserID);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ResultModel UpdateUserInfo(UserViewModel user);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        ResultModel ResetPassWord(Guid UserID, string pass);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="OldPass"></param>
        /// <param name="NewPass"></param>
        /// <returns></returns>
        ResultModel UpdatePassWord(Guid UserID, string OldPass, string NewPass);




    }
}
