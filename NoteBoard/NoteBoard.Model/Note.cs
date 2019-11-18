using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.Model
{
    public class Note:BaseEntity
    {
        public int NoteID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // nav prop

        public virtual User User { get; set; } // Bir kişinin bir notu olacak.


    }
}
