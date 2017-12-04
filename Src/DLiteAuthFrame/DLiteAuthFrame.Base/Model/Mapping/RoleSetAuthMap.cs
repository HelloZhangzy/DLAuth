using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class RoleSetAuthMap:EntityTypeConfiguration<RoleSetAuth>
    {
        public RoleSetAuthMap()
        {
            ToTable("RoleSetAuth");

            HasKey(t => t.ID);

            HasRequired(t => t.Role).WithMany(t => t.RoleSetAuth).HasForeignKey(t => t.RoleCode).WillCascadeOnDelete(false);

            HasRequired(t => t.SetAuthCodeEntity).WithMany(t => t.RoleSetAuth).HasForeignKey(t => t.SetAuthCode).WillCascadeOnDelete(false);                       
            
        }

    }
}
