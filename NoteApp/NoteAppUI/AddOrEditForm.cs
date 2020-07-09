using System;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class AddOrEditForm : Form
    {
        /// <summary>
        /// Заметка
        /// </summary>
        private Note _note;

        /// <summary>
        /// Возвращает и задает заметку
        /// </summary>
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                if (_note != null)
                {
                    CategoryComboBox.Text = _note.Category.ToString();
                    CreationDatePicker.Value = _note.CreationTime;
                    ModifierDatePicker.Value = _note.LastChangeTime;
                    NoteContentTextBox.Text = _note.Text;
                }
                else
                {
                    _note = new Note();
                }

                TitleTextBox.Text = _note.Name;
            }
        }

        public AddOrEditForm()
        {
            InitializeComponent();
            FillCategoryComboBox();
        }

        /// <summary>
        /// Метод, заполняющий выпадающий список категорий
        /// </summary>
        private void FillCategoryComboBox()
        {
            CategoryComboBox.Items.Add(NoteCategory.Documents);
            CategoryComboBox.Items.Add(NoteCategory.Finance);
            CategoryComboBox.Items.Add(NoteCategory.HealthAndSport);
            CategoryComboBox.Items.Add(NoteCategory.Home);
            CategoryComboBox.Items.Add(NoteCategory.People);
            CategoryComboBox.Items.Add(NoteCategory.Work);
            CategoryComboBox.Items.Add(NoteCategory.Other);
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            Note.Name = TitleTextBox.Text;
        }

        private void CategoryComboBox_TextChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedItem != null)
            {
                Note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
            }
        }

        private void NoteContentTextBox_TextChanged(object sender, EventArgs e)
        {
            Note.Text = NoteContentTextBox.Text;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}