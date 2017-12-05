using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using DLiteAuthFrame.APP.APP;
using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Base.Model;
using DLiteAuthFrame.Base.Repository;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Domain.Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DLiteAuthFrame.Base.AutoFac
{
    public static class AutofacExt
    {        
        private static IContainer _container;

        public static void InitAutofac(IContainer Container)
        {
            _container = Container;
        }


        public static T Resolve<T>(Parameter parameters)
        {
            return _container.Resolve<T>(parameters);
        }

        /// <summary>
        /// 从容器中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
            //   return (T)DependencyResolver.Current.GetService(typeof(T));
        }
    }  
}
