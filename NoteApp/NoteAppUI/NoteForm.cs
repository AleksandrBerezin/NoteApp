using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using NoteApp;

namespace NoteAppUI
{
    //TODO: кнопка Cancel смещена относительно правого края - не выровнена относительно текстовых полей выше
    //TODO: просто NoteForm. Когда я в комментарии писал "редактируемый_объект" + Form, слово Edit не подразумевалось в названии
    public partial class NoteForm : Form
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
                
                TitleTextBox.Text = _note.Name;
                CategoryComboBox.SelectedItem = _note.Category;
                CreationDatePicker.Text = _note.CreationTime.ToShortDateString();
                ModifiedDatePicker.Text = _note.LastChangeTime.ToShortDateString();
                NoteContentTextBox.Text = _note.Text;
            }
        }

        public NoteForm()
        {
            InitializeComponent();
            FillCategoryComboBox();
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
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Note.Name = TitleTextBox.Text;
                TitleTextBox.BackColor = Color.White;
                ModifiedDatePicker.Text = _note.LastChangeTime.ToShortDateString();
            }
            catch (ArgumentException exception)
            {
                TitleTextBox.BackColor = Color.LightCoral;
            }
        }

        private void CategoryComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Если значение не определено в перечислении, то выбросит исключение
                Enum.IsDefined(typeof(NoteCategory), CategoryComboBox.SelectedItem);
                Note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
                CategoryComboBox.BackColor = Color.White;

                ModifiedDatePicker.Text = _note.LastChangeTime.ToShortDateString();
            }
            catch (JsonSerializationException exception) //TODO: ловить исключения базового типа плохо. Здесь и в других местах конкретизируй тип ожидаемого исключения
            {
                CategoryComboBox.BackColor = Color.LightCoral;
            }
        }

        private void NoteContentTextBox_TextChanged(object sender, EventArgs e)
        {
            Note.Text = NoteContentTextBox.Text;
            ModifiedDatePicker.Text = _note.LastChangeTime.ToShortDateString();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.BackColor == Color.LightCoral ||
                CategoryComboBox.BackColor == Color.LightCoral)
            {
                MessageBox.Show("Invalid values entered",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}