using NoteBoard.DAL.Mapping;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NoteBoard.DAL
{
    public class NoteBoardDbContext:DbContext
    {
        public NoteBoardDbContext()
            :base("NoteBoardDBContext")
        {
            Database.SetInitializer(new NoteBoardDbInitializer());
        }

        public DbSet<User> Users{ get; set; } //Veritabanında oluşacak tablonun adı ("Users").
        public DbSet<Password> Password { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Mappingler getirildi.
            modelBuilder.Configurations.Add(new NoteMapping());
            modelBuilder.Configurations.Add(new PasswordMapping());
            modelBuilder.Configurations.Add(new UserMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();// Veritabanında oluşan tablolar "s" takısı almaz.

        }

    }
}
