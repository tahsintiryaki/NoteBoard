using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.Model
{
    public enum UserRole
    {
        //Standart=0 Eğer bu şekilde tanımlarsak standartın index numarası 0 admin'in index numarası 1 olur.
        //Fakat bu şekilde Admin'in ixdexi 0 standartın indexi 1.
        Admin,
        Standart
    }
}
