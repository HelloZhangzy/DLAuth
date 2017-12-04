using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class SetAuthCodeMap:EntityTypeConfiguration<SetAuthCode>
    {
        public SetAuthCodeMap()
        {
            ToTable("SetAuthCode");

            HasKey(t => t.ID);

            Property(t => t.SetAuthName).HasMaxLength(200);

        }

    }
}
