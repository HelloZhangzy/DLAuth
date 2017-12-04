using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;


namespace DLiteAuthFrame.Base.Model.Mapping
{
    class OrgRoleMap:EntityTypeConfiguration<OrgRole>
    {
        public OrgRoleMap()
        {
            ToTable("OrgRoleMap");

            HasKey(t => t.ID);

            HasRequired(t => t.Organization).WithMany(t => t.OrgRole).HasForeignKey(t => t.OrgCode);
            HasRequired(t => t.Role).WithMany(t => t.OrgRole).HasForeignKey(t => t.RoleCode);
        }
    }
}
