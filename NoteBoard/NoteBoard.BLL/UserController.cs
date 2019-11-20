using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
    public class UserController
    {
        UserDAL _userDAL;

        public UserController()
        {
            _userDAL = new UserDAL();
        }

        public bool Add(User user)
        {
            // kullanıcı kayıt olduktan sorna kullanıcı hesabı admın onayından geçmeden kullanıcı giriş yapmasın

            try
            {
                if (user.Passwords.Count > 0)
                {
                    user.IsActive = false;
                    user.CreatedDate = DateTime.Now;
                    user.Passwords.First().IsActive = true;
                    // şifre değiştirildikten sonra tekrar create date olusturuyoruz.
                    user.Passwords.First().CreatedDate = DateTime.Now;

                    _userDAL.Add(user);
                    return true;// kayıt eklenirse true dönücek kayıt eklemede hata olursa else düşecek zaten.
                }
                else
                {
                    throw new Exception("Şifre yok");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(User user)
        {
            try
            {
                user.ModifiedDate = DateTime.Now;
                _userDAL.Update(user);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Delete(User user)
        {
            //burdan silinen hasabı pasife çekip bilgilerini update ederek veritabanında saklıyoruz.
            user.IsActive = false;
            return Update(user);
            //hesap 30 günden fazla pasif kalırsa veritabanından silinsin?
        }

        public User GetByID(int userID)
        {
            return _userDAL.GetByID(userID);
        }
        public User GetByLogin(string username, string password)
        {
            List<User> users = _userDAL.GetAll();
            //Username uqique olarak tanımlı.
            User user = users.Where(a => a.IsActive && a.UserName == username).SingleOrDefault();//Single olabilir mi?
            if (user != null)
            {
                Password pass = user.Passwords.Where(a => a.IsActive && a.PasswordText == password).Single();
                if (pass==null)
                {
                    return null;
                }
            }
            return user;
        }

        public List<User> GetAll()
        {
            return _userDAL.GetAll();
        }

    }
}
