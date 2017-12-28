using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Domain.IRepository
{
    public interface IOrgRepository : IRepository<Organization>
    {
        /// <summary>
        /// 根据用户编号获取二级组织机构信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<Organization> GetOrgs(Guid UserID);

        ///// <summary>
        ///// 删除指定ID
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <param name="Msg"></param>
        ///// <returns></returns>
        //bool DeleteOrg(Guid ID, ref string Msg);
    }
}
