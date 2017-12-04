using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class SystemParameterMap:EntityTypeConfiguration<SystemParameter>
    {
        public SystemParameterMap()
        {
            ToTable("SystemParameter");

            HasKey(t => t.ParameterCode);

            Property(t => t.Explain).HasMaxLength(300);
            Property(t => t.ParameterValue).HasMaxLength(1000);
            
        }
    }
}
