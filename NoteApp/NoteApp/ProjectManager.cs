using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    //TODO: посмотри, как я сделал ссылку на класс через <see cref>. Здесь и везде делать ссылки именно так вместо указания имени класса в кавычках. Такие кросс-ссылки помогают быстрее передвигаться по документации, плюс это защита на случай, если класс переименуется
    /// <summary>
    /// Класс <see cref="ProjectManager"/>, выполняющий сохранение проекта в файл и загрузку проекта из файла
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Название файла.
        /// </summary>
        private const string FileName = "NoteApp.notes";

        //TODO: только не мои документы, а AppData с созданием подпапки для твоей программы. В Моих документах очень легко удалить папку 
        //TODO: переделать в открытое свойство DefaultPath
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private static readonly string _path = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + FileName;

        //TODO: путь должен передаваться аргументом в метод, чтобы сделать класс более гибким в использовании (например, если в будущем добавить в программу разных пользоватлей, можно будет сохранять заметки разных пользователей в разные файлы)
        //TODO: но в текущей реализации метод должен вызывать с дефолтным путем, который клиентский код будет забирать из открытого свойства этого класса.
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

        //TODO: метод должен принимать путь
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

            //TODO: отработать вариант, когда десериализовать не удалось (например, содержание файла повреждено)
            using (StreamReader sr = new StreamReader(_path))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }

            return project;
        }
    }
}