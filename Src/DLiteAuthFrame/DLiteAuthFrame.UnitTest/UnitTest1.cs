﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLiteAuthFrame.Base.Model;
using DLiteAuthFrame.Base;
using DLiteAuthFrame.Base.AutoFac;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            { 
                DLAuthContext dldb = new DLAuthContext();
                dldb.Database.CreateIfNotExists();

                Assert.IsNotNull(dldb);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(true, false, ex.Message);
            } 
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                AutofacExt.InitAutofac();

                IUnitOfWork work = AutofacExt.Resolve<IUnitOfWork>();

                var re = work.GetRepository<User>();
                User us = new User();
                us.CreaterDate = System.DateTime.Now;
                // us.CreateUserCode = Guid.NewGuid();
                us.ibState = true;
                us.LastLoginDate = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
                us.LoginCount = 0;
                us.LoginPass = "";
                us.UpdateDate = DateTime.Now;
                us.UpdateUserCode = Guid.Empty;
                us.UserCode = Guid.NewGuid();
                us.UserExplain = "";
                us.UserName = "admin";
                re.Create(us);

                Assert.IsTrue(work.Commit());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, false, ex.Message);
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            try
            {
                AutofacExt.InitAutofac();

                IUnitOfWork work = AutofacExt.Resolve<IUnitOfWork>();

                var re = work.GetRepository<User>();

                re.All();               
                
                Assert.IsTrue(re.Count>0,re.Count.ToString());

            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, false, ex.Message);
            }
        }
    }
}