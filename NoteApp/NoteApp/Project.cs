using System.Collections.Generic;
using System.Linq;

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
        
        /// <summary>
        /// Возвращает и задает список заметок
        /// </summary>
        public List<Note> Notes { get; set; }

        /// <summary>
        /// Возвращает и задает текущую заметку
        /// </summary>
        public Note CurrentNote { get; set; }

        /// <summary>
        /// Создает экземпляр <see cref="Project"/>
        /// </summary>
        public Project()
        {
            Notes = new List<Note>();
        }

        /// <summary>
        /// Метод для сортировки списка заметок по дате изменения (по убыванию)
        /// </summary>
        /// <returns></returns>
        public List<Note> Sort() //TODO: отразить в названии, что сортировка идет по дате изменения. Лучшее название метода то, которое не требует чтения комментариев
        {
            var orderedList = 
                Notes.OrderByDescending(note => note.LastChangeTime);
            return orderedList.ToList();
        }

        /// <summary>
        /// Метод для сортировки списка заметок по дате изменения (по убыванию)
        /// при определенной категории
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Note> Sort(NoteCategory category) //TODO: не просто сортирует, но еще и фильтрует по заданной категории. Отразить в названии или разделить на два отдельно используемых метода
        {
            return Notes.OrderByDescending(note =>
                note.LastChangeTime).Where(note => note.Category == category).ToList();
        }
    }
}