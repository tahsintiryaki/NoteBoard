using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NoteBoard.Model;

namespace NoteBoard.DAL
{
    class NoteBoardDbInitializer : CreateDatabaseIfNotExists<NoteBoardDbContext>
    {
        protected override void Seed(NoteBoardDbContext context)
        {
            User user = new User()
            {
                FirstName = "Egitim",
                LastName = "Sart",
                UserName = "admin",
                UserRole = UserRole.Admin,
                IsActive = true,
                CreatedDate = DateTime.Now             
            };
            user.Passwords.Add(new Password()
            {
                PasswordText = "Esk123",
                IsActive = true,
                CreatedDate = DateTime.Now
            });

            context.Users.Add(user);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
