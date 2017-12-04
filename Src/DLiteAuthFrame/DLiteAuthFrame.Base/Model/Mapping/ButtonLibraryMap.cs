using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Base.Model.Mapping
{
    class ButtonLibraryMap: EntityTypeConfiguration<ButtonLibrary>
    {
        public ButtonLibraryMap()
        {
            //Table
            ToTable("ButtonLibrary", "dbp");
            //Key
            HasKey(t => t.ButtonCode);
            //Property
            this.Property(t => t.Explain).HasMaxLength(300);
            this.Property(t => t.IcoUrl).HasMaxLength(300);
        }
    }
}
