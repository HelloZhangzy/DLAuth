using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DLiteAuthFrame.APP.APP
{
    public class OrgManageApp:IOrgManageApp
    {
        public IOrgRepository orgRository { get; set; }

        public List<JSTreeViewModel> Get_CurrUser_OrgNode()
        {
            var UserID = DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(UserID)) return null;
            var data = orgRository.GetOrgs(Guid.Parse(UserID)).ToList();

            List<JSTreeViewModel> treeModel = new List<JSTreeViewModel>();
            foreach (var item in data)
            {               
                treeModel.Add(ToJsTreeVM(item,true));
            }
            return treeModel;
        }       

        public List<JSTreeViewModel> Get_Org_OrgNode(Guid ID)
        {
            var data = orgRository.GetOrgNode(ID).ToList();

            List<JSTreeViewModel> treeModel = new List<JSTreeViewModel>();
            
            foreach (var item in data.Where(t=>t.ParentCode==ID))
            {                
                treeModel.Add(ToJsTreeVM(item, data.Where(t => t.ParentCode == item.OrgCode).Count() > 0));
            }
           
            return treeModel;
        }

        private JSTreeViewModel ToJsTreeVM(Organization org, bool IsChildren)
        {
            JSTreeViewModel vm = new JSTreeViewModel();
            vm.id = org.OrgCode.ToString();
            vm.children = IsChildren;
            vm.text = org.OrgName;
            if (org.ParentCode == Guid.Empty)
                vm.parent = "#";
            else
                vm.parent = org.ParentCode.ToString();
            vm.state = JSTreeState.Create(false);
            return vm;
        }

        /// <summary>
        /// 获取当前用户可查询的机构
        /// </summary>
        /// <returns></returns>
        public List<OrgViewModel> GetOrgTree()
        {
            var UserID = DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(UserID)) return null;

            var data = orgRository.GetOrgs(Guid.Parse(UserID)).OrderBy(t=>t.OrgCode).ToList();
            List<OrgViewModel> Org_ls = new List<OrgViewModel>();
            ToTreeViewModel(Org_ls, data, 0, Guid.Empty);
            return Org_ls;
        }

        /// <summary>
        /// 获取机构信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public OrgViewModel GetOrgInfo(Guid ID)
        {
            var item = orgRository.Filter(t => t.OrgCode == ID).FirstOrDefault();           
            if (item != null)
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
                return ov;
            }
            return null;
        }
                 
        /// <summary>
        /// 获取当前用户可查机构SelectListItem
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetOrgSelect(Guid ID)
        {
            var UserID = DLSession.GetCurrLoginCode();

            if (string.IsNullOrWhiteSpace(UserID)) return null;

            var data = orgRository.GetOrgs(Guid.Parse(UserID)).ToList();
            
            List<SelectListItem> ls = new List<SelectListItem>();
            
            ToViewModel(ls, data, "",Guid.Empty,ID);
            
            return ls;
        }

        /// <summary>
        /// 修改机构
        /// </summary>
        /// <param name="ovm"></param>
        /// <returns></returns>
        public AjaxResult Update(OrgViewModel ovm)
        {
            var org = orgRository.Find(t => t.OrgCode == ovm.OrgCode);
            if (org != null)
            {
                org.ParentCode = ovm.ParentCode;
                org.OrgExplain = ovm.OrgExplain;
                org.OrgName = ovm.OrgName;
                org.UpdateDate = DateTime.Now;
                org.UpdateUserCode = Guid.Parse(DLSession.GetCurrLoginCode());
                orgRository.Update(org);
                return new AjaxResult { state = ResultType.success.ToString(), message = "操作成功！", data = null };
            }
            return new AjaxResult { state = ResultType.error.ToString(), message = "未找到机构！", data = null };            
        }

        /// <summary>
        /// 新增机构
        /// </summary>
        /// <param name="ovm"></param>
        /// <returns></returns>
        public AjaxResult Add(OrgViewModel ovm)
        {
            var Count = orgRository.Filter(t => t.OrgName == ovm.OrgName && t.ParentCode==ovm.ParentCode).Count();

            if (Count > 0) return new AjaxResult { state = ResultType.error.ToString(), message = "机构已存在！", data = null };

            Organization org = new Organization();
            org.OrgCode=Guid.NewGuid();
            org.ParentCode = ovm.ParentCode;
            org.OrgName = ovm.OrgName;
            org.OrgExplain = ovm.OrgExplain;
            org.CreaterDate = DateTime.Now;
            org.CreateUserCode =Guid.Parse(DLSession.GetCurrLoginCode());
            orgRository.Create(org);
            return new AjaxResult { state = ResultType.success.ToString(), message = "操作成功！", data = null };
        }

        public AjaxResult Delete(Guid ID)
        {
            var org = orgRository.Find(t => t.OrgCode == ID);
            if (org==null) return new AjaxResult { state = ResultType.error.ToString(), message = "机构不存在！", data = null };

            var count = orgRository.Filter(t => t.ParentCode == org.OrgCode).Count();
            if (count>0)
            {
                return new AjaxResult { state = ResultType.error.ToString(), message = "存在子机构，请先删除子机构！", data = null };
            }
            else
            {
                orgRository.Delete(org);
                return new AjaxResult { state = ResultType.success.ToString(), message = "操作成功！", data = null };
            }
        }

        private List<OrgViewModel> ToTreeViewModel(List<Organization> orgs)
        {
            List<OrgViewModel> Org_ls = new List<OrgViewModel>();

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
                ov.level = 0;
                ov.parent = Guid.Empty;
                ov.isLeaf = false;
                ov.expanded = true;
                Org_ls.Add(ov);
                ToTreeViewModel(Org_ls,orgs.Where(t=>t.ParentCode==item.OrgCode).ToList(),0, item.OrgCode);
            }

            return Org_ls;
        }

        private void ToTreeViewModel(List<OrgViewModel> ls,List<Organization> orgs,int Level, Guid ParentOrgCode)
        {
            foreach (var item in orgs.Where(t=>t.ParentCode==ParentOrgCode))
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

                ov.level = Level;
                ov.id = item.OrgCode;
                ov.parent = item.ParentCode;
                if (orgs.Where(t => t.ParentCode == item.OrgCode).Count() > 0)
                { 
                    ov.isLeaf = false;
                    ov.expanded = true;
                }
                else
                { 
                   ov.isLeaf = true;
                   ov.expanded = false;
                }
                ov.loaded = true;
                
                ls.Add(ov);
                if (orgs.Where(t=>t.ParentCode==item.OrgCode).Count()>0)
                {
                    ToTreeViewModel(ls, orgs, Level + 1, item.OrgCode);
                }                
            }
        }

        /// <summary>
        /// 转换为树型
        /// </summary>
        /// <param name="orgs"></param>
        /// <returns></returns>
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

        ///// <summary>
        ///// 转换为Select标签识别类型
        ///// </summary>
        ///// <param name="orgs"></param>
        ///// <returns></returns>
        //private List<SelectListItem> ToViewModel(List<Organization> orgs)
        //{
        //    List<SelectListItem> ovm = new List<SelectListItem>();
        //    SelectListItem rootItem = new SelectListItem();
        //    rootItem.Value = "00000000-0000-0000-0000-000000000000";
        //    rootItem.Text = "根节点";
        //    rootItem.Disabled = true;
        //    ovm.Add(rootItem);
        //    foreach (var item in orgs)
        //    {
        //        SelectListItem ov = new SelectListItem();
        //        ov.Value = item.OrgCode.ToString();
        //        ov.Text = item.OrgName;
        //        ovm.Add(ov);
        //        //ToViewModel(ovm, orgs.Where(t => t.OrgCode == item.OrgCode).ToList(), "  ", item.OrgCode);
        //    }
        //    return ovm;
        //}

        /// <summary>
        /// 递归转换为select标签识别类型
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="orgs"></param>
        /// <param name="Lines"></param>
        /// <param name="ParentID"></param>
        private void ToViewModel(List<SelectListItem> ls, List<Organization> orgs, string Lines, Guid ParentID,Guid DisableID)
        {
            Guid toID = Guid.Empty;

            foreach (var item in orgs.Where(t => t.ParentCode == ParentID))
            {
                SelectListItem ov = new SelectListItem();
                ov.Value = item.OrgCode.ToString();
                ov.Text = Lines +" "+ item.OrgName;               
                if (DisableID==item.OrgCode)
                { 
                  toID = item.OrgCode;
                  ov.Disabled = true;
                }
                else
                { 
                  toID = DisableID;
                  ov.Disabled = false;
                }
                ls.Add(ov);
                ToViewModel(ls, orgs, Lines + "—", item.OrgCode, toID);
            }
        }
    }
}
