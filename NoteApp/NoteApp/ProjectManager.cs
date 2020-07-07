using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс "Менеджер проекта", выполняющий сохранение проекта в файл и загрузку проекта из файла
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Название файла.
        /// </summary>
        private const string FileName = "NoteApp.notes";

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private static readonly string _path = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + FileName;

        /// <summary>
        /// Метод для сохранения данных в файл
        /// </summary>
        public static void SaveToFile(Project data)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(_path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Метод для загрузки данных из файла
        /// </summary>
        public static Project LoadFromFile()
        {
            NoteApp.Project project = null;

            JsonSerializer serializer = new JsonSerializer();

            if (!File.Exists(_path))
            {
                return new Project();
            }

            using (StreamReader sr = new StreamReader(_path))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }

            return project;
        }
    }
}