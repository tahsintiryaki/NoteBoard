using NoteBoard.BLL;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteBoard.UI.WinForm
{
    public partial class frmRegister : Form
    {
        UserController _userController;
        public frmRegister()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text!=txtPaswordAgain.Text)
            {
                MessageBox.Show("Şifreler Eşleşmiyor.");
            }
            User newUser = new User();
            newUser.FirstName = txtFirstName.Text;
            newUser.LastName= txtLastName.Text;
            newUser.UserName = txtUserName.Text;
            newUser.UserRole = UserRole.Standart;
            newUser.Passwords.Add(new Password()
            {
                PasswordText = txtPassword.Text
            });

            try
            {
                bool result = _userController.Add(newUser);
                if (result)
                {
                    MessageBox.Show("Kayıt Başarılı, kullanıcı onay süreciniz başladı");
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {

                    this.Owner.Show();
        }
    }
}
