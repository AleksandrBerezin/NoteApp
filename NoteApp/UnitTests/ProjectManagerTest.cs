using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        [Test(Description = "Позитивный тест геттера DefaultPath")]
        public void TestDefaultPathGet_CorrectValue()
        {
            var expected =
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp";
            ProjectManager.DefaultPath = expected;
            var actual = ProjectManager.DefaultPath;

            Assert.AreEqual(expected, actual, "Геттер DefaultPath возвращает неправильный путь");
        }

        [Test(Description = "Позитивный тест сеттера DefaultPath")]
        public void TestDefaultPathSet_CorrectValue()
        {
            var expected =
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
            location = Path.GetFullPath(location + "\\..\\..\\NoteApp.notes");

            if (File.Exists(location))
            {
                File.Delete(location);
            }

            ProjectManager.SaveToFile(project, Path.GetFullPath(location + "\\.."));
            Assert.IsFalse(!File.Exists(location), "Файл для сохранения данных не был создан");

            var expectedFileAsText = File.ReadAllText(location);
            var testDataLocation =
                Path.GetFullPath(location + "\\..\\..\\TestData\\NoteApp.notes");
            var actualFileAsText = File.ReadAllText(testDataLocation);

            Assert.AreEqual(expectedFileAsText, actualFileAsText,
                "Метод SaveToFile сохраняет данные неверно");
        }

        [Test(Description = "Позитивный тест метода загрузки данных из файла")]
        public void TestLoadFromFile_CorrectValue()
        {
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
            var testDataLocation =
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
            location = Path.GetFullPath(location + "\\..\\..\\NoteApp.notes");

            if (File.Exists(location))
            {
                File.Delete(location);
            }

            ProjectManager.SaveToFile(project, Path.GetFullPath(location + "\\.."));
            var corruptedText = File.ReadAllText(location);
            corruptedText = corruptedText.Substring(100, corruptedText.Length - 150);
            File.WriteAllText(location, corruptedText);

            Project actualProject;

            Assert.Throws<JsonSerializationException>(
                () => { actualProject = ProjectManager.LoadFromFile(location + "\\.."); },
                    "Должно возникать исключение, если файл поврежден");
        }
    }
}