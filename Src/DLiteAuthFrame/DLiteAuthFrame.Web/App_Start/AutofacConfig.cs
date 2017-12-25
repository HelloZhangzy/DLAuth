using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using DLiteAuthFrame.APP.APP;
using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Base.AutoFac;
using DLiteAuthFrame.Base.Model;
using DLiteAuthFrame.Base.Repository;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Domain.Services.AuthServices;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


namespace DLiteAuthFrame.Web
{
    public class AutofacConfig
    {
        private static IContainer _container;

        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();            

            //注册DB上下文
            builder.RegisterType(typeof(DLAuthContext)).As(typeof(DbContext));

            //注册数据库基础操作和工作单元
            ILog log = LogManager.GetLogger("log4net");
            builder.RegisterInstance(log).As<ILog>().SingleInstance();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));
            builder.RegisterType(typeof(UserService)).As(typeof(IUserService));
            builder.RegisterType(typeof(AuthApp)).As(typeof(IAuthApp));
            builder.RegisterType(typeof(UserRepository)).As(typeof(IUserRepository));
            builder.RegisterType(typeof(OrgRository)).As(typeof(IOrgRository));

            // 注册controller，使用属性注入
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            //// OPTIONAL: Register web abstractions like HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();

            //// OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            // 注册所有的Attribute
            builder.RegisterFilterProvider();         
            

            // Set the dependency resolver to be Autofac.
            _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

            AutofacExt.InitAutofac(_container);
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