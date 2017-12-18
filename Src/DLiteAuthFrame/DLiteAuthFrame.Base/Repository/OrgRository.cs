﻿using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DLiteAuthFrame.Base.Repository
{
    public class OrgRository : Repository<Organization>, IOrgRository
    {
        public OrgRository(DbContext context) : base(context)
        {

        }

        public IQueryable<Organization> GetOrgs(Guid UserID)
        {
            return from a in Context.Set<OrgUser>()
                   join b in Context.Set<Organization>() on a.OrgCode equals b.OrgCode
                   where a.UserCode == UserID
                   select b;
        }

        public bool DeleteOrg(Guid ID, ref string Msg)
        {
            if (Context.Set<OrgUser>().Where(t => t.OrgCode == ID).Count()>0)
            {
                Msg = "机构已使用，不能删除";
                return false;
            }

            Delete(t=>t.OrgCode==ID);

            return true;
        }

    }
}
