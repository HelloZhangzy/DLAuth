﻿using DLiteAuthFrame.APP.IApp;
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
        public IOrgRository orgRository { get; set; }

        /// <summary>
        /// 获取当前用户可查询的机构
        /// </summary>
        /// <returns></returns>
        public List<OrgViewModel> GetOrgTree()
        {
            var UserID = DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(UserID)) return null;

            var data = orgRository.GetOrgs(Guid.Parse(UserID));
            return ToTreeViewModel(data.ToList());
        }

        /// <summary>
        /// 获取机构信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public OrgViewModel GetOrgInfo(string ID)
        {
            var item = orgRository.Filter(t => t.OrgCode.ToString() == ID).FirstOrDefault();
           
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
        public List<SelectListItem> GetOrgSelect()
        {
            var UserID = DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(UserID)) return null;

            var data = orgRository.GetOrgs(Guid.Parse(UserID)).ToList();
            return ToViewModel(data);
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
            org.ParentCode = ovm.ParentCode;
            org.OrgName = ovm.OrgName;
            org.OrgExplain = ovm.OrgExplain;
            org.CreaterDate = DateTime.Now;
            org.CreateUserCode =Guid.Parse(DLSession.GetCurrLoginCode());
            orgRository.Create(org);
            return new AjaxResult { state = ResultType.success.ToString(), message = "操作成功！", data = null };
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
                ov.parent = 0;
                ov.isLeaf = false;
                ov.expanded = true;
                Org_ls.Add(ov);
                ToTreeViewModel(Org_ls,orgs.Where(t=>t.ParentCode==item.OrgCode).ToList(),0, item.OrgCode);
            }

            return Org_ls;
        }

        private void ToTreeViewModel(List<OrgViewModel> ls,List<Organization> orgs,int ParentLevel, Guid ParentOrgCode)
        {
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
                ov.level = ParentLevel+1;
                ov.parent = ParentLevel;
                ov.isLeaf = true;
                ov.expanded = false;
                ls.Add(ov);
                ToTreeViewModel(ls, orgs.Where(t => t.ParentCode == item.OrgCode).ToList(), ParentLevel+1, item.OrgCode);
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

        /// <summary>
        /// 转换为Select标签识别类型
        /// </summary>
        /// <param name="orgs"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 递归转换为select标签识别类型
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="orgs"></param>
        /// <param name="Lines"></param>
        /// <param name="ParentID"></param>
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

    }
}