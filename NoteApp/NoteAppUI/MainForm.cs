using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    //TODO: иконки для кнопок слишком бледные, ощущение что они отключены
    //TODO: запускаю программу, создаю три заметки: две категории Other, одну - Home. Выбираю для отображения категорию Other, редактирую одну из заметок, меняю в ней категорию. Закрываю второе окно - в списке заметок показываются все заметки, а не выбранной категории
    //TODO: при растягивании окна контролы почему-то начинают отъезжать от главного меню. Исправить верстку
    //TODO: где билд ивенты?
    public partial class MainForm : Form
    {
        /// <summary>
        /// Проект
        /// </summary>
        private Project _project;

        /// <summary>
        /// Список заметок, сортированный по дате изменения //TODO: сортированный для чего? Надо указывать назначение объекта, а то, что он сортированный - это вторично
        /// </summary>
        private List<Note> sortedNotes; //TODO: лист чего? Для коллекций тип коллекции не указывается, указывается имя сущности в множественном числе

        public MainForm()
        {
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);

            InitializeComponent();
            FillCategoryComboBox();

            sortedNotes = _project.LastChangeTimeSort();
            _project.Notes = sortedNotes;

            FillNoteListBox();

            if (_project.CurrentNote != null)
            {
                var currentNoteIndex = _project.Notes.IndexOf(_project.CurrentNote);
                NotesListBox.SelectedItem = NotesListBox.Items[currentNoteIndex];
            }
        }

        /// <summary>
        /// Метод, заполняющий выпадающий список категорий
        /// </summary>
        private void FillCategoryComboBox()
        { //TODO: AddRange?
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

            foreach (var note in sortedNotes)
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

            var realIndexInProject = _project.Notes.IndexOf(sortedNotes[selectedIndex]);
            _project.CurrentNote = _project.Notes[realIndexInProject];

            NoteTitleTextBox.Text = sortedNotes[selectedIndex].Name;
            CategoryTextBox.Text = sortedNotes[selectedIndex].Category.ToString();
            CreatedDatePicker.Text =
                sortedNotes[selectedIndex].CreationTime.ToShortDateString();
            ModifiedDatePicker.Text =
                sortedNotes[selectedIndex].LastChangeTime.ToShortDateString();
            NoteContentTextBox.Text = sortedNotes[selectedIndex].Text;
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            var inner = new NoteForm();
            inner.Note = new Note();
            var result = inner.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var newNote = inner.Note;
            _project.Notes.Add(newNote);

            sortedNotes = _project.LastChangeTimeSort();
            _project.Notes = sortedNotes;

            FillNoteListBox();

            var currentNoteIndex = _project.Notes.IndexOf(newNote);
            NotesListBox.SelectedItem = NotesListBox.Items[currentNoteIndex];
            CategoryComboBox.Text = "";

            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            var selectedIndex = NotesListBox.SelectedIndex;
            var selectedNote = sortedNotes[selectedIndex];
            var realIndexInProject = _project.Notes.IndexOf(selectedNote);

            var inner = new NoteForm();
            inner.Note = (Note)selectedNote.Clone();
            var result = inner.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var updatedNote = inner.Note;
            _project.Notes.RemoveAt(realIndexInProject);
            _project.Notes.Insert(realIndexInProject, updatedNote);

            if (CategoryComboBox.SelectedItem != null)
            {
                sortedNotes = _project.LastChangeTimeSortWithCategory(
                    (NoteCategory) CategoryComboBox.SelectedItem);
            }
            else
            {
                sortedNotes = _project.LastChangeTimeSort();
            }

            FillNoteListBox();

            if (CategoryComboBox.SelectedItem != null)
            {
                if (updatedNote.Category.Equals((NoteCategory)CategoryComboBox.SelectedItem))
                {
                    var currentNoteIndex = sortedNotes.IndexOf(updatedNote);
                    NotesListBox.SelectedItem = NotesListBox.Items[currentNoteIndex];
                }
                else
                {
                    if (NotesListBox.Items.Count > 0)
                    {
                        NotesListBox.SelectedItem = NotesListBox.Items[0];
                    }
                    else
                    {
                        ClearAllFields();
                    }
                }
            }
            else
            {
                NotesListBox.SelectedItem = NotesListBox.Items[0];
            }

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
                var selectedNote = sortedNotes[selectedIndex];
                var realIndexInProject = _project.Notes.IndexOf(selectedNote);

                _project.Notes.RemoveAt(realIndexInProject);
                sortedNotes = _project.LastChangeTimeSort();
                _project.Notes = sortedNotes;

                FillNoteListBox();
                _project.CurrentNote = null;
                ClearAllFields();
                CategoryComboBox.Text = "";

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
                sortedNotes = _project.Notes;
            }
            else
            {
                sortedNotes = _project.LastChangeTimeSortWithCategory(
                    (NoteCategory)CategoryComboBox.SelectedIndex);
            }

            NotesListBox.Items.Clear();
            
            foreach (var note in sortedNotes)
            {
                NotesListBox.Items.Add(note.Name);
            }
        }

        private void ClearAllFields()
        {
            NoteTitleTextBox.Clear();
            CategoryTextBox.Clear();
            CreatedDatePicker.Text = DateTime.Now.ToString();
            ModifiedDatePicker.Text = DateTime.Now.ToString();
            NoteContentTextBox.Clear();
        }
    }
}