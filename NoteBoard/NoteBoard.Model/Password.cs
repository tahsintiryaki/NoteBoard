using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.Model
{
    public class Password:BaseEntity
    {
        public int PasswordNum { get; set; }

        public int UserID { get; set; }

        public string PasswordText { get; set; }

        //Nav prop
        public virtual User User { get; set; } // Bir şifrenin bir kullanıcısı olucak
    }
}
