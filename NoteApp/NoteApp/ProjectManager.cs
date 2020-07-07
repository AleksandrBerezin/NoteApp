using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс "Менеджер проекта", выполняющий сохранение проекта в файл и загрузку проекта из файла
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Название файла.
        /// </summary>
        private const string FileName = "NoteApp.notes";

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private readonly string _path = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + FileName;
    }
}