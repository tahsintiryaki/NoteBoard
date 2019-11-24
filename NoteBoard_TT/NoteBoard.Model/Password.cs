using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.Model
{
    public class Password :BaseEntity
    {
        public int PasswordNum { get; set; }
        public int UserID { get; set; }
        public string PasswordText { get; set; }

        public virtual User User { get; set; }
    }
}
