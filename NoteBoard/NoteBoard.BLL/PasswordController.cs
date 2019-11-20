using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
    public class PasswordController
    {
        PasswordDAL _passwordDAL;

        public PasswordController()
        {
            _passwordDAL = new PasswordDAL();
        }
        public bool Add(Password pass)
        {
            List<Password> passwords = GetAllByUser(pass.UserID);
            passwords = passwords.OrderByDescending(a => a.CreatedDate).Take(3).ToList();
            if (passwords.FirstOrDefault(a => a.PasswordText == pass.PasswordText) != null)
            {
                throw new Exception("Son 3 şifreden farklı bir şifre giriniz!");
            }
            if (passwords.FirstOrDefault() != null)
            {
                Delete(passwords.First());
                //Patlayacak mı?
            }
            pass.IsActive = true;
            pass.CreatedDate = DateTime.Now;
            return _passwordDAL.Add(pass) > 0;
        }

        List<Password> GetAllByUser(int userID)
        {
            return _passwordDAL.GetAll().Where(a => a.UserID == userID).ToList();
        }

        public bool Delete(Password pass)
        {
            pass.IsActive = false;
            pass.ModifiedDate = DateTime.Now;
            return _passwordDAL.Update(pass) > 0;
        }
        
        public Password GetActivePassword(int userID)
        {
            List<Password> allPasswords = GetAllByUser(userID);
            return allPasswords.Where(a => a.IsActive).SingleOrDefault();
        }
    }
}
