using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Domain.IServices.IAuthservices
{
    public interface IOrgService
    {
        /// <summary>
        /// 删除指定ID机构
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        bool Delete(Guid ID, ref string Msg);

        AjaxResult Update(Organization ov);

    }
}
