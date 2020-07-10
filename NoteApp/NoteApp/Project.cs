using System.Collections.Generic;

namespace NoteApp
{
    /// <summary>
    /// Класс <see cref="Project"/>, хранящий список заметок
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список всех заметок
        /// </summary>
        private List<Note> _notes;
        
        //TODO: это можно было сделать автосвойством - меньше кода, лучше читаемость
        /// <summary>
        /// Возвращает и задает список заметок
        /// </summary>
        public List<Note> Notes { get; set; }

        /// <summary>
        /// Создает экземпляр <see cref="Project"/>
        /// </summary>
        public Project()
        {
            Notes = new List<Note>();
        }
    }
}