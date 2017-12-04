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
        public DLAuthContext() : base("name=DLAuthContext")
        {
            
        }

        public virtual DbSet<ButtonLibrary> ButtonLibrary { get; set; }
        public virtual DbSet<Code> Code { get; set; }
        public virtual DbSet<CodeType> CodeType { get; set; }
        public virtual DbSet<LoginLog> LoginLog { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuButton> MenuButton { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrgRole> OrgRole { get; set; }
        public virtual DbSet<OrgUser> OrgUser { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleAuth> RoleAuth { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }
        public virtual DbSet<RoleMenuButton> RoleMenuButton { get; set; }
        public virtual DbSet<RoleSetAuth> RoleSetAuth { get; set; }
        public virtual DbSet<SetAuthCode> SetAuthCode { get; set; }
        public virtual DbSet<SystemLog> SystemLog { get; set; }
        public virtual DbSet<SystemParameter> SystemParameter { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserSet> UserSet { get; set; }

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

            Database.SetInitializer<DLAuthContext>(new DBInit());
        }
    }
}
