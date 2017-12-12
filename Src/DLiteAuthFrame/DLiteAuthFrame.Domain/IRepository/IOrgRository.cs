﻿using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Domain.IRepository
{
    public interface IOrgRository : IRepository<Organization>
    {
        /// <summary>
        /// 根据用户编号获取组织机构
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<Organization> GetOrgs(Guid UserID);
    }
}