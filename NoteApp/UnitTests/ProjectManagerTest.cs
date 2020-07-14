using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;
//TODO: тестирование с эталонными файлами сделано не так, как описано в документе!
namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        [Test(Description = "Позитивный тест геттера DefaultPath")]
        public void TestDefaultPathGet_CorrectValue()
        {
            var expected = //TODO: зачем каждый раз указывать эту строку? Её можно один раз задать в закрытом поле и везде вызывать, без дублирования?
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp";
            ProjectManager.DefaultPath = expected;
            var actual = ProjectManager.DefaultPath;

            Assert.AreEqual(expected, actual, "Геттер DefaultPath возвращает неправильный путь");
        }

        [Test(Description = "Позитивный тест сеттера DefaultPath")]
        public void TestDefaultPathSet_CorrectValue()
        {
            var expected = //TODO: см. выше
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp";
            ProjectManager.DefaultPath = expected;
            var actual = ProjectManager.DefaultPath;

            Assert.AreEqual(expected, actual, "Сеттер DefaultPath присваивает неправильный путь");
        }

        [Test(Description = "Позитивный тест метода сохранения данных в файл")]
        public void TestSaveToFile_CorrectValue()
        {
            var project = new Project();
            project.Notes = new List<Note>()
            {
                new Note("Заметка 1", NoteCategory.Home, "Текст1",
                    new DateTime(), new DateTime()),
                new Note("Заметка 2", NoteCategory.Home, "Текст2",
                    new DateTime(), new DateTime()),
                new Note("Заметка 3", NoteCategory.Home, "Текст3",
                    new DateTime(), new DateTime()),
                new Note("Заметка 4", NoteCategory.Home, "Текст4",
                    new DateTime(), new DateTime()),
            };

            var location = Assembly.GetExecutingAssembly().Location;
            //TODO: переход на две папки выше будет падать при других конфигурациях сборки - об этом написано в документе. Переделать
            location = Path.GetFullPath(location + "\\..\\..\\NoteApp.notes");

            if (File.Exists(location))
            {
                File.Delete(location);
            }
            //TODO: выход за папку bin проекта - начинаем создавать левые файлы по всему решению. Переделать
            ProjectManager.SaveToFile(project, Path.GetFullPath(location + "\\.."));
            Assert.IsFalse(!File.Exists(location), "Файл для сохранения данных не был создан");

            var expectedFileAsText = File.ReadAllText(location);
            var testDataLocation = //TODO: см. выше
                Path.GetFullPath(location + "\\..\\..\\TestData\\NoteApp.notes");
            var actualFileAsText = File.ReadAllText(testDataLocation);

            Assert.AreEqual(expectedFileAsText, actualFileAsText,
                "Метод SaveToFile сохраняет данные неверно");
        }

        [Test(Description = "Позитивный тест метода загрузки данных из файла")]
        public void TestLoadFromFile_CorrectValue()
        {
            //TODO: дублируется код по созданию проекта - вынести в общий метод или поле
            var expectedProject = new Project();
            expectedProject.Notes = new List<Note>()
            {
                new Note("Заметка 1", NoteCategory.Home, "Текст1",
                    new DateTime(), new DateTime()),
                new Note("Заметка 2", NoteCategory.Home, "Текст2",
                    new DateTime(), new DateTime()),
                new Note("Заметка 3", NoteCategory.Home, "Текст3",
                    new DateTime(), new DateTime()),
                new Note("Заметка 4", NoteCategory.Home, "Текст4",
                    new DateTime(), new DateTime()),
            };

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataLocation = //TODO: см. выше
                Path.GetFullPath(location + "\\..\\..\\..\\TestData");
            var actualProject = ProjectManager.LoadFromFile(testDataLocation);
            
            CollectionAssert.AreEqual(expectedProject.Notes, actualProject.Notes,
                "Метод LoadFromFile загружает данные неверно");
        }

        [Test(Description = "Тест метода загрузки данных из файла при отсутствии файла")]
        public void TestLoadFromFile_NoFile()
        {
            var expectedProject = new Project();
            var location = Assembly.GetExecutingAssembly().Location;
            var actualProject = ProjectManager.LoadFromFile(Path.GetFullPath(location));

            CollectionAssert.AreEqual(expectedProject.Notes, actualProject.Notes,
                "Метод LoadFromFile не создает новый объект Project при отсутствии файла");
        }

        [Test(Description = "Тест метода загрузки данных из поврежденного файла")]
        public void TestLoadFromFile_CorruptedFile()
        {
            //TODO: зачем здесь создавать проект? тест должен проверить возникновение исключения при загрузке эталонного файла
            var project = new Project();
            project.Notes = new List<Note>()
            {
                new Note("Заметка 1", NoteCategory.Home, "Текст1",
                    new DateTime(), new DateTime()),
                new Note("Заметка 2", NoteCategory.Home, "Текст2",
                    new DateTime(), new DateTime()),
                new Note("Заметка 3", NoteCategory.Home, "Текст3",
                    new DateTime(), new DateTime()),
                new Note("Заметка 4", NoteCategory.Home, "Текст4",
                    new DateTime(), new DateTime()),
            };
            //TODO: см. выше
            var location = Assembly.GetExecutingAssembly().Location;
            location = Path.GetFullPath(location + "\\..\\..\\NoteApp.notes");

            if (File.Exists(location))
            {
                File.Delete(location);
            }
            //TODO: см. выше
            //TODO: в тестировании загрузки файла не должно вызываться сохранение. Вместо этого работа только с эталонными файлами
            //TODO: зачем вообще нужно программно создавать поврежденный файл? Юнит-тесты должны быть максимально простыми и содержать только тот код, который нужен для вызова тестируемого метода и его проверки. Любые дополнительные действия в случае падения юнит-теста усложняют поиск причин ошибки
            ProjectManager.SaveToFile(project, Path.GetFullPath(location + "\\.."));
            var corruptedText = File.ReadAllText(location);
            corruptedText = corruptedText.Substring(100, corruptedText.Length - 150);
            File.WriteAllText(location, corruptedText);

            Project actualProject;
            //TODO: см. выше
            Assert.Throws<JsonSerializationException>(
                () => { actualProject = ProjectManager.LoadFromFile(location + "\\.."); },
                    "Должно возникать исключение, если файл поврежден");
        }
    }
}