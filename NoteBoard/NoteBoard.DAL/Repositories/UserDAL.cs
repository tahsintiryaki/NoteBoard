using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Repositories
{
    class UserDAL
    {
        NoteBoardDbContext _db;

        public UserDAL()
        {
            _db = new NoteBoardDbContext();
        }

        public int Add(User user)
        {
            _db.Entry(user).State = EntityState.Added;// Durum kontrolu yapar veri yoksa ekler varsa bir şey yapmaz. Alttakine göre daha detyalı bir kod.

            //_db.Users.Add(user);
            return _db.SaveChanges();
        }

        public int Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            return _db.SaveChanges();
        }
        public int Delete(User user)
        {
            _db.Entry(user).State = EntityState.Deleted;
            return _db.SaveChanges();
        }
        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetByID(int userID)
        {
            return _db.Users.FirstOrDefault(a => a.UserID == userID); // users içerisinde dönsün buldukları arasından ilkini getir. gelmezse hata verme.
        }
    }
}
