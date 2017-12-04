using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class OrganizationMap:EntityTypeConfiguration<Organization>
    {
        public OrganizationMap()
        {
            ToTable("Organization");

            HasKey(t => t.OrgCode);

            Property(t => t.OrgExplain).HasMaxLength(300);
            Property(t => t.OrgName).HasMaxLength(200);
            
        }
    }
}
