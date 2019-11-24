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
        User _currentUser;
        PasswordController _passwordController;
        NoteController _noteController;
        public frmMain(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _passwordController = new PasswordController();
            _noteController = new NoteController();
        }

        private void frmMain_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Hoşgeldin "+ _currentUser.UserName;
            lblWelcome.ForeColor = Color.LightGreen;
            FillNote();
           
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(_passwordController.GetActivePassword(_currentUser.UserID));
            frm.Owner = this;
            frm.ShowDialog();
        }
        public void FillNote()
        {
            List<Note> notes = _noteController.GetNotesByUser(_currentUser.UserID);
            lstNotes.DisplayMember = "Title";
            lstNotes.ValueMember = "NoteID";
            lstNotes.DataSource = notes;
            lstNotes.SelectedIndex = -1;
        }

        public void AddNote()
        {
            Note note = new Note();
            note.Title = txtTitle.Text;
            note.Content = txtContent.Text;
            note.UserID = _currentUser.UserID;

            bool result = _noteController.Add(note);
            try
            {
                if (result)
                {
                    MessageBox.Show("Notunuz başarıyla kaydedildi.");
                    txtContent.Clear();
                    txtTitle.Clear();
                    FillNote();
                }
                else
                {
                    MessageBox.Show("Notunuz kaydedilirken bir hata olustu");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateNote()
        {
            int noteID = (int)lstNotes.SelectedValue;
            Note updateNote= _noteController.GetByID(noteID);
            updateNote.Title = txtTitle.Text;
            updateNote.Content = txtContent.Text;
            bool result = _noteController.Update(updateNote);
            try
            {
                if (result)
                {
                    MessageBox.Show("Notunuz Güncellendi");
                    txtContent.Clear();
                    txtTitle.Clear();
                    FillNote();
                }
                else
                {
                    MessageBox.Show("Notunuz güncellenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text) ||string.IsNullOrWhiteSpace(txtTitle.Text)|| string.IsNullOrEmpty(txtContent.Text) || string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Başlık veya içerik kısmı boş geçilemez!");
                return;
            }
            if (lstNotes.SelectedIndex<0)
            {
                AddNote();
            }
            else
            {
                UpdateNote();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstNotes.SelectedIndex<0)
            {
                
                MessageBox.Show("Silmek istediğiniz notu seçiniz!");
                return;
            }
          
            Note deleteNote = _noteController.GetByID((int)lstNotes.SelectedValue);
            deleteNote.UserID = _currentUser.UserID;
            bool result = _noteController.Delete(deleteNote);

            if (result)
            {
                MessageBox.Show("Notunuz başarıyla silindi");
                FillNote();
            }
            else
            {
                MessageBox.Show("Notunuz silinirken bir hata oluştu");
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex >= 0)
            {
                Note selectedNote = lstNotes.SelectedItem as Note;
                txtTitle.Text = selectedNote.Title;
                txtContent.Text = selectedNote.Content;
                btnSave.Text = "Güncelle";
            }
            else
            {
                btnSave.Text = "Kaydet";
            }
        }
    }
}
