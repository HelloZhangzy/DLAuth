using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Domain.Services.AuthServices
{
    class OrgService : IOrgService
    {
        IOrgRository orgRository = null;

        public OrgService(IOrgRository _org)
        {
            orgRository = _org;
        }

        public bool Delete(Guid ID, ref string Msg)
        {
            orgRository.Delete(t => t.OrgCode == ID);
            return true;
        }

        public AjaxResult Update(Organization ov)
        {
            var org = orgRository.Find(t => t.OrgCode == ov.OrgCode);

            if (org != null)
            {
                org.ParentCode = ov.ParentCode;
                org.OrgExplain = ov.OrgExplain;
                org.OrgName = ov.OrgName;
                org.UpdateDate = DateTime.Now;
                org.UpdateUserCode = Guid.Parse(DLSession.GetCurrLoginCode());
                orgRository.Update(org);

                return new AjaxResult { state = ResultType.success.ToString(), message = "操作成功！", data = null };
            }

            return new AjaxResult { state = ResultType.error.ToString(), message = "未找到机构！", data = null };
        }

    }
}
