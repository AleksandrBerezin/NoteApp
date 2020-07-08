using System.Collections.Generic;

namespace NoteApp
{
    /// <summary>
    /// Класс проекта, хранящий список заметок
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список всех заметок
        /// </summary>
        private List<Note> _notes;
        //TODO: xml
        //TODO: это можно было сделать автосвойством - меньше кода, лучше читаемость
        public List<Note> Notes
        {
            get
            {
                return _notes;
            }

            set
            {
                _notes = value;
            }
        }

        public Project()
        {
            Notes = new List<Note>();
        }
    }
}