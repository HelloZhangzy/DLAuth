using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Base.Cookis_Session;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Domain.Model;
using DLiteAuthFrame.Web.App_Start.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.Web.Areas.SystemManage.Controllers
{
    public class OrgManageController : Controller
    {
        IOrgRository orgRository = null;

        IOrgService orgService = null;

        public OrgManageController(IOrgService _ser, IOrgRository _org)
        {
            orgService = _ser;
            orgRository = _org;
        }

        // GET: SystemManage/Org
        [AuthAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrgs()
        {
            List<OrgViewModel> data = GetOrgList();
            return Content(data.ToJson());
        }

        private List<OrgViewModel> GetOrgList()
        {
            var UserID = DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(UserID)) return null;

            var data = orgRository.GetOrgs(Guid.Parse(UserID));
            return ToViewModel(data);
        }

        [HttpPost]
        public ActionResult GetOrg(string ID)
        {           
            return Content(GetOrganization(ID).ToJson());           
        }

        public ActionResult UpdateOrg(OrgViewModel ov)
        {
            if (ov != null)
            {
                Organization org = new Organization();
                org.ParentCode = ov.ParentCode;
                org.OrgExplain = ov.OrgExplain;
                org.OrgName = ov.OrgName;
                org.UpdateDate = DateTime.Now;
                org.UpdateUserCode =Guid.Parse(DLSession.GetCurrLoginCode());
                return Content(orgService.Update(org).ToJson());
            }

            return Content(new AjaxResult { state = ResultType.error.ToString(), message = "未找到机构！", data = null }.ToJson());
        }
         

        private OrgViewModel GetOrganization(string ID)
        {
            var item = orgRository.Filter(t => t.OrgCode.ToString() == ID).FirstOrDefault();
            OrgViewModel ov = new OrgViewModel();
            if (item != null)
            {
                ov.CreaterDate = item.CreaterDate;
                ov.CreateUserCode = item.CreateUserCode;
                ov.OrgCode = item.OrgCode;
                ov.OrgExplain = item.OrgExplain;
                ov.OrgName = item.OrgName;
                ov.ParentCode = item.ParentCode;
                ov.UpdateDate = item.UpdateDate;
                ov.UpdateUserCode = item.UpdateUserCode;
            }
            return ov;
        }

        private List<OrgViewModel> ToViewModel(IQueryable<Organization> orgs)
        {
            List<OrgViewModel> ovm = new List<OrgViewModel>();

            foreach (var item in orgs)
            {
                OrgViewModel ov = new OrgViewModel();
                ov.CreaterDate = item.CreaterDate;
                ov.CreateUserCode = item.CreateUserCode;
                ov.OrgCode = item.OrgCode;
                ov.OrgExplain = item.OrgExplain;
                ov.OrgName = item.OrgName;
                ov.ParentCode = item.ParentCode;
                ov.UpdateDate = item.UpdateDate;
                ov.UpdateUserCode = item.UpdateUserCode;
                ovm.Add(ov);
            }
            return ovm;
        }

        private List<SelectListItem> ToViewModel(List<Organization> orgs)
        {
            List<SelectListItem> ovm = new List<SelectListItem>();
            SelectListItem rootItem = new SelectListItem();
            rootItem.Value = "00000000-0000-0000-0000-000000000000";
            rootItem.Text = "根节点";
            rootItem.Disabled = true;
            ovm.Add(rootItem);
            foreach (var item in orgs)
            {
                SelectListItem ov = new SelectListItem();
                ov.Value = item.OrgCode.ToString();
                ov.Text = item.OrgName;
                ovm.Add(ov);
                ToViewModel(ovm, orgs.Where(t => t.OrgCode == item.OrgCode).ToList(), "  ", item.OrgCode.ToString());
            }
            return ovm;
        }

        private void ToViewModel(List<SelectListItem> ls, List<Organization> orgs, string Lines, string ParentID = "00000000-0000-0000-0000-000000000000")
        {
            foreach (var item in orgs.Where(t => t.ParentCode.ToString() == ParentID))
            {
                SelectListItem ov = new SelectListItem();
                ov.Value = item.OrgCode.ToString();
                ov.Text = item.OrgName;
                ls.Add(ov);
                ToViewModel(ls, orgs.Where(t => t.OrgCode == item.OrgCode).ToList(), Lines + "  ", item.OrgCode.ToString());
            }
        }

        [AuthAttribute]
        public ActionResult Edit(string ID)
        {            
            var org=GetOrganization(ID);

            var data = orgRository.GetOrgs(Guid.Parse(DLSession.GetCurrLoginCode()));

            var ls = ToViewModel(data.ToList());
          
            ls.Where(t => t.Value == org.ParentCode.ToString()).FirstOrDefault().Selected = true;

            var temp = ls.Where(t => t.Value == ID).FirstOrDefault();
            if (temp!=null)
            {
                temp.Disabled = false;
            }

            ViewData["OrgViewModel"] = org;
            ViewData["OrgList"] = new SelectList(ls, "Value", "Text"); 
            return View();
        }
    }
}