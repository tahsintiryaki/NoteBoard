using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Repositories
{
    public class UserDAL
    {
        NoteBoardDbContext _db;
        public UserDAL()
        {
            _db = new NoteBoardDbContext();
        }

        public int Add(User user)
        {
            _db.Entry(user).State = EntityState.Added;
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
            return _db.Users.FirstOrDefault(x=>x.UserID==userID);
        }

    }
}
