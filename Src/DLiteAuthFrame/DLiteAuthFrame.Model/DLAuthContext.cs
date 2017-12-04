namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DLAuthContext : DbContext
    {
        public DLAuthContext()
            : base("name=DLAuthContext1")
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
            modelBuilder.Entity<ButtonLibrary>()
                .Property(e => e.IcoUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ButtonLibrary>()
                .Property(e => e.Explain)
                .IsUnicode(false);

            modelBuilder.Entity<Code>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Code>()
                .Property(e => e.EnValue)
                .IsUnicode(false);

            modelBuilder.Entity<Code>()
                .Property(e => e.ZhValue)
                .IsUnicode(false);

            modelBuilder.Entity<Code>()
                .Property(e => e.CodeExplain)
                .IsUnicode(false);

            modelBuilder.Entity<CodeType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<CodeType>()
                .Property(e => e.TypeExplain)
                .IsUnicode(false);

            modelBuilder.Entity<LoginLog>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<LoginLog>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<LoginLog>()
                .Property(e => e.ComputerName)
                .IsUnicode(false);

            modelBuilder.Entity<LoginLog>()
                .Property(e => e.LoginIP)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.MenuExplain)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.OrgName)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.OrgExplain)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleExplain)
                .IsUnicode(false);

            modelBuilder.Entity<RoleAuth>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<SetAuthCode>()
                .Property(e => e.SetAuthName)
                .IsUnicode(false);

            modelBuilder.Entity<SetAuthCode>()
                .HasMany(e => e.RoleSetAuth)
                .WithOptional(e => e.SetAuthCode1)
                .HasForeignKey(e => e.SetAuthCode);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.LogSource)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.LogTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.LogTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.LogText)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.LogExplain)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemParameter>()
                .Property(e => e.ParameterValue)
                .IsUnicode(false);

            modelBuilder.Entity<SystemParameter>()
                .Property(e => e.Explain)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserExplain)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LoginPass)
                .IsUnicode(false);

            modelBuilder.Entity<UserSet>()
                .Property(e => e.SetCode)
                .IsUnicode(false);

            modelBuilder.Entity<UserSet>()
                .Property(e => e.SetName)
                .IsUnicode(false);

            modelBuilder.Entity<UserSet>()
                .Property(e => e.SetExplain)
                .IsUnicode(false);
        }
    }
}
