using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Repositories
{
    public class PasswordDAL
    {
        NoteBoardDbContext _db;
        public PasswordDAL()
        {
            _db = new NoteBoardDbContext();
        }

        public int Add(Password pass)
        {
            _db.Entry(pass).State = EntityState.Added;
            return _db.SaveChanges();
        }

        public int Update(Password pass)
        {
            _db.Entry(pass).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public int Delete(Password pass)
        {
            _db.Entry(pass).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public List<Password> GetAll()
        {
            return _db.Passwords.ToList();
        }

        public Password GetByID(int passID)
        {
            return _db.Passwords.FirstOrDefault(x => x.PasswordNum == passID);
        }
    }
}
