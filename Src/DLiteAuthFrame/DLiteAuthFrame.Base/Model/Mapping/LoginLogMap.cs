using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class LoginLogMap:EntityTypeConfiguration<LoginLog>
    {
        public LoginLogMap()
        {
            ToTable("LoginLog", "dbo");
            HasKey(t => t.ID);

            Property(t => t.ComputerName).HasMaxLength(300);
            Property(t => t.LoginIP).HasMaxLength(100);
            Property(t => t.RoleName).HasMaxLength(200);
            Property(t => t.UserName).HasMaxLength(200);            
        }
    }
}
