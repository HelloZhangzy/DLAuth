using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class UserRoleMap:EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable("UserRole");

            HasKey(t => t.ID);

            HasRequired(t => t.Role).WithMany(t => t.UserRole).HasForeignKey(t => t.RoleCode).WillCascadeOnDelete(false);

            HasRequired(t => t.User).WithMany(t => t.UserRole).HasForeignKey(t => t.UserCode).WillCascadeOnDelete(false);

        }
    }
}
