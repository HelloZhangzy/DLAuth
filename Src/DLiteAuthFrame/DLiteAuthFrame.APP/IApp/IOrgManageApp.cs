using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DLiteAuthFrame.APP.IApp
{
    public interface IOrgManageApp
    {
        /// <summary>
        /// 获取机构信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        OrgViewModel GetOrgInfo(string ID);

        /// <summary>
        /// 获取当前用户可查询的机构Tree
        /// </summary>
        /// <returns></returns>
        List<OrgViewModel> GetOrgTree();

        /// <summary>
        /// 获取当前用户可查机构SelectListItem
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetOrgSelect();

        /// <summary>
        /// 修改机构
        /// </summary>
        /// <param name="ovm"></param>
        /// <returns></returns>
        AjaxResult Update(OrgViewModel ovm);

        /// <summary>
        /// 新增机构
        /// </summary>
        /// <param name="ovm"></param>
        /// <returns></returns>
        AjaxResult Add(OrgViewModel ovm);
    }
}
