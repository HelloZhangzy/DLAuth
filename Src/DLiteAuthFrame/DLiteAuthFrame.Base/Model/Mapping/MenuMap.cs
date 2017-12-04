using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class MenuMap:EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            ToTable("Menu", "dbo");

            HasKey(t => t.MenuCode);

            Property(t => t.MenuExplain).HasMaxLength(300);
            Property(t => t.MenuName).HasMaxLength(200);
            Property(t => t.Url).HasMaxLength(1000);
            
        }
    }
}
