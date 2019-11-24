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
    public partial class frmAdmin : Form
    {
        UserController _userController;
        public frmAdmin()
        {
            InitializeComponent();
            _userController = new UserController();
        }
        public void FillUser()
        {
            lstUsers.Items.Clear();
            List<User> allUsers = _userController.GetAll().Where(x => x.UserRole == UserRole.Standart).ToList();
            ListViewItem lvi;
            foreach (User item in allUsers)
            {
               lvi = new ListViewItem(item.FirstName);
                lvi.SubItems.Add(item.LastName);
                lvi.SubItems.Add(item.UserName);
                lvi.SubItems.Add(item.IsActive?"Aktif":"Pasif");
                lvi.Tag = item;
                lstUsers.Items.Add(lvi);
            }
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            FillUser();
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItems.Count>0)
            {
                ListViewItem selected = lstUsers.SelectedItems[0];
                User selectedUser = selected.Tag as User;

                if (selectedUser.IsActive==false)
                {
                    DialogResult result = MessageBox.Show("Kullanıcıyı onaylamak istiyor musunuz", "Onay", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result==DialogResult.Yes)
                    {
                        selectedUser.IsActive = true;
                        _userController.Update(selectedUser);
                        FillUser();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Kullanıcıyı karalisteye almak istiyor musunuz?","Kara liste",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                    if (result==DialogResult.Yes)
                    {
                        selectedUser.IsActive = false;
                        _userController.Update(selectedUser);
                        FillUser();
                    }
                }
            }
        }

        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
