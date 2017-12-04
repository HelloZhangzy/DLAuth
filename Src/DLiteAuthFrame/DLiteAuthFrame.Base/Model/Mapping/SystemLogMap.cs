using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class SystemLogMap:EntityTypeConfiguration<SystemLog>
    {
        public SystemLogMap()
        {
            ToTable("SystemLog");

            HasKey(t => t.ID);

            Property(t => t.LogExplain).HasMaxLength(1000);
            Property(t => t.LogSource).HasMaxLength(100);
            Property(t => t.LogText).HasMaxLength(2000);
            Property(t => t.LogTypeCode).HasMaxLength(200);
            Property(t => t.LogTypeName).HasMaxLength(200);
            Property(t => t.UserName).HasMaxLength(300);
        }
    }
}
