using System.Collections.Generic;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        /// <summary>
        /// Метод для создания списка заметок на 4 элемента
        /// </summary>
        /// <returns></returns>
        private List<Note> GetExampleList()
        {
            return new List<Note>()
            {
                new Note("Заметка 1", NoteCategory.Home, "Текст 1"),
                new Note("Заметка 2", NoteCategory.Work, "Текст 2"),
                new Note("Заметка 3", NoteCategory.Documents, "Текст 3"),
                new Note("Заметка 4", NoteCategory.Other, "Текст 4")
            };
        }

        [Test(Description = "Позитивный тест геттера Notes")]
        public void TestNotesGet_CorrectValue()
        {
            var expected = GetExampleList();
            var project = new Project();
            project.Notes = expected;
            var actual = project.Notes;

            CollectionAssert.AreEqual(expected, actual,
                "Геттер Notes возвращает неправильный список заметок");
        }

        [Test(Description = "Позитивный тест сеттера Notes")]
        public void TestNotesSet_CorrectValue()
        {
            //TODO: дублирование создания списка - вынести в метод или поле
            var expected = GetExampleList();
            var project = new Project();
            project.Notes = expected;
            var actual = project.Notes;

            CollectionAssert.AreEqual(expected, actual,
                "Сеттер Notes присваивает неправильный список заметок");
        }

        [Test(Description = "Позитивный тест конструктора Project")]
        public void TestProjectConstructor_CorrectValue()
        {
            var project = new Project();
            var isNull = project == null;

            Assert.IsFalse(isNull, "Конструктор не создал экземпляр класса Project");
        }
    }
}