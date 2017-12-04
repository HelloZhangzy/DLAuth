using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class RoleMenuMap:EntityTypeConfiguration<RoleMenu>
    {
        public RoleMenuMap()
        {
            ToTable("RoleMenu");

            HasKey(t => t.ID);

            HasRequired(t => t.Menu).WithMany(t => t.RoleMenu).HasForeignKey(t => t.MenuCode).WillCascadeOnDelete(false);
            HasRequired(t => t.Role).WithMany(t => t.RoleMenu).HasForeignKey(t => t.RoleCode).WillCascadeOnDelete(false);
           
        }

    }
}
