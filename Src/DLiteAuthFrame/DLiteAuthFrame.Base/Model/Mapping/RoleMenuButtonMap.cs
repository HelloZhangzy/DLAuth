using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class RoleMenuButtonMap:EntityTypeConfiguration<RoleMenuButton>
    {
        public RoleMenuButtonMap()
        {
            ToTable("RoleMenuButton");

            HasKey(t => t.ID);

            HasRequired(t => t.ButtonLibrary).WithMany(t => t.RoleMenuButton).HasForeignKey(t => t.ButtonCode).WillCascadeOnDelete(false);
            HasRequired(t => t.Menu).WithMany(t => t.RoleMenuButton).HasForeignKey(t => t.MenuCode).WillCascadeOnDelete(false);
            HasRequired(t => t.Role).WithMany(t => t.RoleMenuButton).HasForeignKey(t => t.RoleCode).WillCascadeOnDelete(false);

        }
    }
}
