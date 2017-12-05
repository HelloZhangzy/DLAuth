using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DLiteAuthFrame.Domain.Model;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;

namespace DLiteAuthFrame.Base.Model
{
    public partial class DLAuthContext : DbContext
    {
        public DLAuthContext() : base("DLAuthContext")
        {
           // Database.SetInitializer(new DBInit());
        }

        public  DbSet<ButtonLibrary> ButtonLibrarys { get; set; }
        public  DbSet<Code> Codes { get; set; }
        public  DbSet<CodeType> CodeTypes { get; set; }
        public  DbSet<LoginLog> LoginLogs { get; set; }
        public  DbSet<Menu> Menus { get; set; }
        public  DbSet<MenuButton> MenuButtons { get; set; }
        public  DbSet<Organization> Organizations { get; set; }
        public  DbSet<OrgRole> OrgRoles { get; set; }
        public  DbSet<OrgUser> OrgUsers { get; set; }
        public  DbSet<Role> Roles { get; set; }
        public  DbSet<RoleAuth> RoleAuths { get; set; }
        public  DbSet<RoleMenu> RoleMenus { get; set; }
        public  DbSet<RoleMenuButton> RoleMenuButtons { get; set; }
        public  DbSet<RoleSetAuth> RoleSetAuths { get; set; }
        public  DbSet<SetAuthCode> SetAuthCodes { get; set; }
        public  DbSet<SystemLog> SystemLogs { get; set; }
        public  DbSet<SystemParameter> SystemParameters { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<UserRole> UserRoles { get; set; }
        public  DbSet<UserSet> UserSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
            Assembly asm = Assembly.GetExecutingAssembly();
            var typesToRegister = asm.GetTypes()
                                    .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
