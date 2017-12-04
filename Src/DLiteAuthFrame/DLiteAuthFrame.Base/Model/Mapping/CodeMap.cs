using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class CodeMap : EntityTypeConfiguration<Code>
    {
        public CodeMap()
        {
            //Table
            ToTable("Code", "dbo");
            //Key
            HasKey(t => t.ID);
            //Property
            this.Property(t => t.CodeExplain).HasMaxLength(300);
            this.Property(t => t.TypeName).HasMaxLength(300);
            this.Property(t => t.ZhValue).HasMaxLength(200);
            this.Property(t => t.EnValue).HasMaxLength(200);

            //Relationships
            this.HasRequired(t => t.CodeType)
                .WithMany(t => t.Code)
                .HasForeignKey(t => t.TypeCode)
                .WillCascadeOnDelete(false);
        }

    }
}
