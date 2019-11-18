using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using NoteBoard.Model;

namespace NoteBoard.DAL.Mapping
{
    class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(u => u.UserID);
            Property(u => u.UserID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);// User ID Identity ve PK oldu. Ama yamzsakta otomatik olarak bu özellikler gelecekti. Solid ' e uygun olması için her şeyi başta ekliyoruz.
            Property(u => u.FirstName).IsRequired().HasMaxLength(20);
            Property(u => u.LastName).IsRequired().HasMaxLength(30);
            Property(u => u.UserName).IsRequired().HasMaxLength(18);

            Map(u => u.MapInheritedProperties());// Inheritance edilmiş propertyleride maple demiş olduk.
            HasIndex(u => u.UserName).IsUnique();//User name Unique yappıldı.
            

        }
    }
}
