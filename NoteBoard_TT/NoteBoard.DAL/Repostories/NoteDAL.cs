using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Repositories
{
    public class NoteDAL
    {
        NoteBoardDbContext _db;
        public NoteDAL()
        {
            _db = new NoteBoardDbContext();
        }

        public int Add(Note not)
        {
            _db.Entry(not).State = EntityState.Added;
            return _db.SaveChanges();
        }

        public int Delete(Note not)
        {
            _db.Entry(not).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public int Update(Note not)
        {
            _db.Entry(not).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public List<Note> GetAll()
        {
            return _db.Notes.ToList();
        }

        public Note GetByID(int notID)
        {
            return _db.Notes.FirstOrDefault(x => x.NoteID == notID);
        }
    }
}
