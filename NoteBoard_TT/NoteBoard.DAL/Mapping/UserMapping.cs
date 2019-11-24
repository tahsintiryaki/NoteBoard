using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace NoteBoard.DAL.Mapping
{
    class UserMapping : EntityTypeConfiguration<Model.User>
    {
        public UserMapping()
        {
            Property(x => x.FirstName).IsRequired().HasMaxLength(20);
            Property(x => x.LastName).IsRequired().HasMaxLength(30);
            Property(x => x.UserName).IsRequired().HasMaxLength(18);

            HasKey(x => x.UserID);
            Property(x => x.UserID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Map(x => x.MapInheritedProperties());

            HasIndex(x => x.UserName).IsUnique();
            
        }
    }
}
