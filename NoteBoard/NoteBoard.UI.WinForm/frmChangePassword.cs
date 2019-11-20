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
        PasswordController _passwordController;
        Password _pass;
        public frmChangePassword(Password pass)
        {
            InitializeComponent();
            _pass = pass;
            _passwordController = new PasswordController();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if(txtOldPasswod.Text !=_pass.PasswordText)
            {
                MessageBox.Show("Şifreniz yanlıs");
                return;
            }else if(txtNewPassword.Text!=txtNewPasswordAgain.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor");
                return;
            }
            Password newPassword = new Password();
            newPassword.PasswordText = txtNewPassword.Text;
            newPassword.UserID = _pass.UserID;

            try
            {
                bool result = _passwordController.Add(newPassword);
                if (result)
                {
                    MessageBox.Show("şifre güncellendi");
                }
                else
                {
                    MessageBox.Show("Şifre güncellenemedi");
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
