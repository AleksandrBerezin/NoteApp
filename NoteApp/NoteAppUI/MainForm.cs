using System;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Проект
        /// </summary>
        private Project _project;

        public MainForm()
        {
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);

            InitializeComponent();
            FillCategoryComboBox();
            FillNoteListBox();

            ExitMenuStrip.ShortcutKeys = Keys.Alt | Keys.F4;
            AboutMenuStrip.ShortcutKeys = Keys.F1;
        }

        /// <summary>
        /// Метод, заполняющий выпадающий список категорий
        /// </summary>
        private void FillCategoryComboBox()
        {
            foreach (var category in Enum.GetValues(typeof(NoteCategory)))
            {
                CategoryComboBox.Items.Add(category);
            }
            CategoryComboBox.Items.Add("All");
        }

        /// <summary>
        /// Метод, заполняющий список заметок
        /// </summary>
        private void FillNoteListBox()
        {
            foreach (var note in _project.Notes)
            {
                NotesListBox.Items.Add(note.Name);
            }
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = NotesListBox.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            }

            NoteTitleTextBox.Text = _project.Notes[selectedIndex].Name;
            CategoryTextBox.Text = _project.Notes[selectedIndex].Category.ToString();
            CreatedDatePicker.Text = 
                _project.Notes[selectedIndex].CreationTime.ToShortDateString();
            ModifiedDatePicker.Text = 
                _project.Notes[selectedIndex].LastChangeTime.ToShortDateString();
            NoteContentTextBox.Text = _project.Notes[selectedIndex].Text;
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            var inner = new EditNoteForm();
            inner.Note = new Note();
            var result = inner.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var newNote = inner.Note;
            _project.Notes.Add(newNote);
            NotesListBox.Items.Add(newNote.Name);

            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            var selectedIndex = NotesListBox.SelectedIndex;
            var selectedNote = _project.Notes[selectedIndex];

            var inner = new EditNoteForm();
            inner.Note = (Note)selectedNote.Clone();
            var result = inner.ShowDialog();
            //TODO: см. выше
            if (result != DialogResult.OK)
            {
                return;
            }

            var updatedNote = inner.Note;

            NotesListBox.Items.RemoveAt(selectedIndex);
            _project.Notes.RemoveAt(selectedIndex);

            _project.Notes.Insert(selectedIndex, updatedNote);
            NotesListBox.Items.Insert(selectedIndex, updatedNote.Name);
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var inner = new AboutForm();
            inner.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Do you really want to remove this note: {NotesListBox.SelectedItem}",
                "Remove Note",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                var selectedIndex = NotesListBox.SelectedIndex;
                NotesListBox.Items.RemoveAt(selectedIndex);
                _project.Notes.RemoveAt(selectedIndex);

                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            }
        }

        private void ExitMenuStrip_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            this.Close();
        }
    }
}