using System;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Model.Mapping
{
    class UserSetMap:EntityTypeConfiguration<UserSet>
    {

        public UserSetMap()
        {
            ToTable("UserSet");

            HasKey(t => t.ID);

            Property(t => t.SetCode).HasMaxLength(100);
            Property(t => t.SetExplain).HasMaxLength(300);
            Property(t => t.SetName).HasMaxLength(200);

            HasRequired(t => t.User).WithMany(t => t.UserSet).HasForeignKey(t => t.UserCode).WillCascadeOnDelete(false);
        }

    }

}
