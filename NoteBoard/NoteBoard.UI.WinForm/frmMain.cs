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
    public partial class frmMain : Form
    {
        User _user;
        PasswordController _passwordController;
        NoteController  _noteController;

        public frmMain(User user)
        {
            InitializeComponent();
            _user = user;
            _passwordController = new PasswordController();
            _noteController = new NoteController();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FillNotes();
        }

        private void lblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password pass = _passwordController.GetActivePassword(_user.UserID);
            //
            frmChangePassword frm = new frmChangePassword(pass);
            frm.Owner = this.Owner; // frm.owner = this ile aynı şey
            frm.Show();
            this.Close();
        }
     
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        public void FillNotes()
        {
            List<Note> notes = _noteController.GetNotesByUser(_user.UserID);
            lstNotes.DisplayMember = "Title";
            lstNotes.ValueMember = "NoteID";
            lstNotes.DataSource = notes;
        }
        private void AddNote()
        {
            Note note = new Note();
            note.Title = txtTitle.Text;
            note.Content = txtContent.Text;
            note.UserID = _user.UserID;
            bool result = _noteController.Add(note);
            if (result)
            {
                MessageBox.Show("Notunuz başarıyl eklendi");
                txtTitle.Clear();
                txtContent.Clear();
                FillNotes();
            }
            else
            {
                MessageBox.Show("Notunuz kayıt edilmedi");
            }
        }
        private void UpdateNote()
        {
            int noteID = (int)lstNotes.SelectedValue;
            Note selected = _noteController.GetByID(noteID);

            selected.Title = txtTitle.Text;
            selected.Content = txtContent.Text;

            bool result = _noteController.Update(selected);
            if (result)
            {
                MessageBox.Show("Güncellendi");
                txtTitle.Clear();
                txtContent.Clear();
                FillNotes();
            }
            else
            {
                MessageBox.Show("Güncellenemedi");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex<0)
            {
                MessageBox.Show("Not seçiniz!");
                return;
            }
            int noteID = (int)lstNotes.SelectedValue;
            Note selected = _noteController.GetByID(noteID);

            bool result = _noteController.Delete(selected);

            if (result)
            {
                MessageBox.Show("Not başarıyla silindi");
                FillNotes();
            }
            else
            {
                MessageBox.Show("Not Silinemedi");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex<0)
            {
                AddNote();
            }
            else
            {
                UpdateNote();
            }
        }
    }

}
