using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(t => t.UserCode);

            Property(t => t.UserExplain).HasMaxLength(300);
            Property(t => t.UserName).HasMaxLength(200);
            Property(t => t.LoginCode).HasMaxLength(100);
        }

    }
}
