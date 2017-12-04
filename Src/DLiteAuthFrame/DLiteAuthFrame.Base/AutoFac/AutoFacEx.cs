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

        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();

            //注册DB上下文
            builder.RegisterType(typeof(DLAuthContext)).As(typeof(DbContext));

            //注册数据库基础操作和工作单元
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();          

            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerDependency();

            builder.RegisterType(typeof(UserService)).As(typeof(IUserService)).InstancePerDependency();

            builder.RegisterType(typeof(AuthApp)).As(typeof(IAuthApp)).InstancePerDependency().PropertiesAutowired();

            //注册app层
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UserManagerApp)));

            //注册领域服务
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AuthoriseService)))
            //    .Where(u => u.Namespace == "OpenAuth.Domain.Service"
            //    || u.Namespace == "OpenAuth.Domain.Interface");

            //注册Repository
            // builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UserRepository))).AsImplementedInterfaces();

            //注册泛型注册Repository
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).WithParameter(new TypedParameter(typeof(DLAuthContext), new DLAuthContext())).InstancePerLifetimeScope();

            //builder.RegisterType()

            // 注册controller，使用属性注入
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
              builder.RegisterSource(new ViewRegistrationSource());

            // 注册所有的Attribute
            builder.RegisterFilterProvider();

            //根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
            //builder.RegisterAssemblyTypes(IRepository, Repository)
            //  .Where(t => t.Name.EndsWith("Repository"))
            //  .AsImplementedInterfaces();

            // Set the dependency resolver to be Autofac.
            _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
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
