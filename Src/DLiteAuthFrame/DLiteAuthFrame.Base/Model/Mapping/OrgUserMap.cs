using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class OrgUserMap : EntityTypeConfiguration<OrgUser>
    {
        public OrgUserMap()
        {          
            // table
            ToTable("OrgUserMap", "dbo");
            // keys
            HasKey(t => t.ID);
            // Property          

            //Relationships
            this.HasRequired(t => t.Organization)
               .WithMany(t => t.OrgUser)
               .HasForeignKey(t => t.OrgCode)
               .WillCascadeOnDelete(false);

            this.HasRequired(t => t.User)
                .WithMany(t => t.OrgUser)
                .HasForeignKey(t => t.UserCode)
                .WillCascadeOnDelete(false);
        }

    }
}
