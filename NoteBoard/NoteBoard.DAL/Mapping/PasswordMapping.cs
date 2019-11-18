using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using NoteBoard.Model;

namespace NoteBoard.DAL.Mapping
{
    class PasswordMapping:EntityTypeConfiguration<Password>
    {
        public PasswordMapping()
        {
            HasKey(p => p.PasswordNum);
            Property(p => p.PasswordNum).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.PasswordText).IsRequired().HasMaxLength(16);

            //Bir passwordun bir tane useri olurken, bir user'ın birden çok passwordu olmalıdır.
            HasRequired(p => p.User) 
                .WithMany(p => p.Passwords)
                .HasForeignKey(p => p.UserID);

            Map(a => a.MapInheritedProperties()); // Inheritance edilmiş propertyleride maple demiş olduk.


        }
    }
}
