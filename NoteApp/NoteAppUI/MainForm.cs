using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Сортированный список заметок
        /// </summary>
        private List<Note> sortedList;

        public MainForm()
        {
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);

            InitializeComponent();
            FillCategoryComboBox();
            FillNoteListBox();

            if (_project.CurrentNote != null)
            {
                var currentNoteIndex = _project.Notes.IndexOf(_project.CurrentNote);
                NotesListBox.SelectedItem = NotesListBox.Items[currentNoteIndex];
            }

            ExitMenuStrip.ShortcutKeys = Keys.Alt | Keys.F4;
            AboutMenuStrip.ShortcutKeys = Keys.F1;
            RemoveNoteStrip.ShortcutKeys = Keys.Delete;
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
            NotesListBox.Items.Clear();
            sortedList = _project.Sort();
            _project.Notes = sortedList;

            foreach (var note in sortedList)
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

            var realIndexInProject = _project.Notes.IndexOf(sortedList[selectedIndex]);
            _project.CurrentNote = _project.Notes[realIndexInProject];

            NoteTitleTextBox.Text = sortedList[selectedIndex].Name;
            CategoryTextBox.Text = sortedList[selectedIndex].Category.ToString();
            CreatedDatePicker.Text =
                sortedList[selectedIndex].CreationTime.ToShortDateString();
            ModifiedDatePicker.Text =
                sortedList[selectedIndex].LastChangeTime.ToShortDateString();
            NoteContentTextBox.Text = sortedList[selectedIndex].Text;
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
            FillNoteListBox();

            var currentNoteIndex = _project.Notes.IndexOf(newNote);
            NotesListBox.SelectedItem = NotesListBox.Items[currentNoteIndex];

            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            var selectedIndex = NotesListBox.SelectedIndex;
            var selectedNote = sortedList[selectedIndex];
            var realIndexInProject = _project.Notes.IndexOf(selectedNote);

            var inner = new EditNoteForm();
            inner.Note = (Note)selectedNote.Clone();
            var result = inner.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var updatedNote = inner.Note;

            _project.Notes.RemoveAt(realIndexInProject);
            _project.Notes.Insert(realIndexInProject, updatedNote);
            FillNoteListBox();

            var currentNoteIndex = _project.Notes.IndexOf(updatedNote);
            NotesListBox.SelectedItem = NotesListBox.Items[currentNoteIndex];

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
                var selectedNote = sortedList[selectedIndex];
                var realIndexInProject = _project.Notes.IndexOf(selectedNote);

                _project.Notes.RemoveAt(realIndexInProject);
                FillNoteListBox();
                _project.CurrentNote = null;

                NoteTitleTextBox.Clear();
                CategoryTextBox.Clear();
                CreatedDatePicker.Text = DateTime.Now.ToString();
                ModifiedDatePicker.Text = DateTime.Now.ToString();
                NoteContentTextBox.Clear();

                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            }
        }

        private void ExitMenuStrip_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            this.Close();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedItem == "All")
            {
                sortedList = _project.Notes;
            }
            else
            {
                sortedList = _project.Sort((NoteCategory)CategoryComboBox.SelectedItem);
            }

            NotesListBox.Items.Clear();
            
            foreach (var note in sortedList)
            {
                NotesListBox.Items.Add(note.Name);
            }
        }
    }
}