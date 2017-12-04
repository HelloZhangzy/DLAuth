using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class CodeTypeMap:EntityTypeConfiguration<CodeType>
    {
        public CodeTypeMap()
        {
            this.ToTable("CodeType", "dbo");
            this.HasKey(t => t.TypeCode);
            this.Property(t => t.TypeExplain).HasMaxLength(300);
            this.Property(t => t.TypeName).HasMaxLength(200);
            
        }
    }
}
