using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс <see cref="ProjectManager"/>, выполняющий сохранение проекта в файл и загрузку проекта из файла
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
        public static string DefaultPath { get; set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            "\\NoteApp";

        /// <summary>
        /// Метод для сохранения данных в файл
        /// </summary>
        public static void SaveToFile(Project data, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path += "\\" + FileName;

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Метод для загрузки данных из файла
        /// </summary>
        public static Project LoadFromFile(string path)
        {
            NoteApp.Project project = null;

            JsonSerializer serializer = new JsonSerializer();

            path += "\\" + FileName;

            if (!File.Exists(path))
            {
                return new Project();
            }

            try
            {
                using (StreamReader sr = new StreamReader(path))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    project = (Project)serializer.Deserialize<Project>(reader);
                }
            }
            catch (Exception e)
            {
                //TODO: какая еще консоль? Убрать любое использование консоли в бизнес-логике
                Console.WriteLine("Файл поврежден.");
                return new Project();
            }

            return project;
        }
    }
}