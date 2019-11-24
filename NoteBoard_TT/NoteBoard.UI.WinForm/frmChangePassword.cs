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
    public partial class frmChangePassword : Form
    {
        Password _pass;
        PasswordController _passwordController;

        public frmChangePassword(Password pass)
        {
            InitializeComponent();
            _pass = pass;
            _passwordController = new PasswordController();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (_pass.PasswordText != txtOldPassword.Text)
            {
                MessageBox.Show("Lütfen değiştirmek istediğiniz şifreyi doğru giriniz!");
                return;
            }
            else if (txtNewPassword.Text!=txtNewPasswordAgain.Text)
            {
                MessageBox.Show("Şifreleriniz eşleşmiyor");
                return;
            }
            _pass.IsActive = false;
            Password newPassword = new Password();
            newPassword.PasswordText = txtNewPassword.Text;
            newPassword.UserID = _pass.UserID;

            try
            {
                bool result = _passwordController.Add(newPassword);
                if (result)
                {
                    MessageBox.Show("Şifreniz Güncellendi");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Şifreniz Güncellenemedi");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
