using System.Collections.Generic;

namespace NoteApp
{
    /// <summary>
    /// Класс проекта, хранящий список всех заметок
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список всех заметок
        /// </summary>
        private List<Note> _notes;

        public List<Note> Notes
        {
            get
            {
                return _notes;
            }

            set
            {
                _notes = Notes;
            }
        }

        public Project()
        {
            Notes = new List<Note>();
        }
    }
}