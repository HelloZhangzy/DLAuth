using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DLiteAuthFrame.Domain.Model;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class MenuButtonMap:EntityTypeConfiguration<MenuButton>
    {
        public MenuButtonMap()
        {
            ToTable("MenuButton", "dbo");
            HasKey(t => t.ID);

            HasRequired(t => t.Menu).WithMany(t => t.MenuButton).HasForeignKey(t => t.MenuCode).WillCascadeOnDelete(false);

            HasRequired(t => t.ButtonLibrary).WithMany(t => t.MenuButton).HasForeignKey(t => t.ButtonCode).WillCascadeOnDelete(false);

        }
    }
}
