using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class RoleMap:EntityTypeConfiguration<Role>
    {

        public RoleMap()
        {
            ToTable("Role");

            HasKey(t => t.RoleCode);
            Property(t => t.RoleExplain).HasMaxLength(300);
            Property(t => t.RoleName).HasMaxLength(200);
        }
    }
}
