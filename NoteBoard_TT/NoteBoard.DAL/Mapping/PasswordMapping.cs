using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Mapping
{
    class PasswordMapping : EntityTypeConfiguration<Model.Password>
    {
        public PasswordMapping()
        {
            Property(x => x.PasswordText).HasMaxLength(16).IsRequired();

            HasRequired(x => x.User).WithMany(x => x.Passwords).HasForeignKey(x => x.UserID);

            Map(x => x.MapInheritedProperties());

            HasKey(x => x.PasswordNum).Property(x => x.PasswordNum).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
