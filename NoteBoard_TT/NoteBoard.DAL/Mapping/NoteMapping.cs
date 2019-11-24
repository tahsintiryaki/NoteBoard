using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Mapping
{
    class NoteMapping : EntityTypeConfiguration<Model.Note>
    {
        public NoteMapping()
        {
            Property(x => x.Title).IsRequired().HasMaxLength(25);
            Property(x => x.Content).IsRequired().HasMaxLength(250);

            HasRequired(x => x.User).WithMany(x => x.Notes).HasForeignKey(x => x.UserID);

            Map(x => x.MapInheritedProperties());

            HasKey(x => x.NoteID).Property(x => x.NoteID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
