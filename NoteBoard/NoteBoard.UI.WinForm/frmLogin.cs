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
    public partial class frmLogin : Form
    {
        UserController _userController;
        public frmLogin()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void linkLblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frmregister = new frmRegister();
            frmregister.Owner = this;
            frmregister.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User currentUser = _userController.GetByLogin(txtUserName.Text, txtPassword.Text);
            if (currentUser!=null)
            {
                if (currentUser.UserRole==UserRole.Standart)
                {
                    frmMain frmMain = new frmMain(currentUser);
                    //frm main ctorunda user göndereceğiz. CurrentUser ile gönderdik.
                    this.Owner = this;
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    frmAdmin frmAdmin = new frmAdmin();
                    frmAdmin.Owner = this;
                    frmAdmin.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Böyle bir kullanıcı yok");
            }
        }
    }
}
