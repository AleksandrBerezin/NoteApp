using System;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    //TODO: добавить программе иконку
    //TODO: меню должно делаться не кнопками,а через MenuStrip
    //TODO: кнопки добавления/редактирования/удаления должны быть плоскими и с пиктограммами
    //TODO: после запуска программы и выбора заметки в списке программа упала с исключением на проверке даты

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
        }

        /// <summary>
        /// Метод, заполняющий выпадающий список категорий
        /// </summary>
        private void FillCategoryComboBox()
        {
            //TODO: вместо отдельных добавлений использовать foreach и метод Enum.GetValues()
            //TODO: кроме перечисления должен быть добавлен еще один вариант All для просмотра всех заметок
            CategoryComboBox.Items.Add(NoteCategory.Documents);
            CategoryComboBox.Items.Add(NoteCategory.Finance);
            CategoryComboBox.Items.Add(NoteCategory.HealthAndSport);
            CategoryComboBox.Items.Add(NoteCategory.Home);
            CategoryComboBox.Items.Add(NoteCategory.People);
            CategoryComboBox.Items.Add(NoteCategory.Work);
            CategoryComboBox.Items.Add(NoteCategory.Other);
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
            //TODO: лучше инвертировать условие с выходом из метода. Уменьшает вложенность в методе, читаемость лучше
            if (selectedIndex >= 0)
            {
                NoteTitleTextBox.Text = _project.Notes[selectedIndex].Name;
                CategoryTextBox.Text = _project.Notes[selectedIndex].Category.ToString();
                CreatedDatePicker.Value = _project.Notes[selectedIndex].CreationTime;
                ModifiedDatePicker.Value = _project.Notes[selectedIndex].LastChangeTime;
                NoteContentTextBox.Text = _project.Notes[selectedIndex].Text;
            }
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            var inner = new AddOrEditForm();
            inner.Note = null; //TODO: а разве он не null по умолчанию?
            inner.ShowDialog();

            //TODO: правильнее результат метода ShowDialog сохранять в переменную и сравнивать в условии уже с ним
            //TODO: сравнить просто через ==
            if (!inner.DialogResult.Equals(DialogResult.OK))
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

            var inner = new AddOrEditForm();
            inner.Note = (Note)selectedNote.Clone();
            inner.ShowDialog();
            //TODO: см. выше
            if (!inner.DialogResult.Equals(DialogResult.OK))
            {
                return;
            }

            var updatedNote = inner.Note;

            NotesListBox.Items.RemoveAt(selectedIndex);
            _project.Notes.RemoveAt(selectedIndex);

            _project.Notes.Insert(selectedIndex, updatedNote);
            NotesListBox.Items.Insert(selectedIndex, updatedNote.Name);
            //TODO: сохранение в файл
        }

        private void HelpButton_Click(object sender, EventArgs e)
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
    }
}