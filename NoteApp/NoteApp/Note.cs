﻿using System;

namespace NoteApp
{
    /// <summary>
    /// Класс заметки, хранящий информацию о названии, категории и тексте заметки,
    /// времени создания и последнего изменения заметки
    /// </summary>
    public class Note : ICloneable
    {
        /// <summary>
        /// Название заметки. Название не должно превышать 50 символов.
        /// </summary>
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Название не должно превышать 50 символов.");
                }

                if (String.IsNullOrEmpty(value))
                {
                    _name = "Без названия";
                }
                else
                {
                    _name = value;
                }

                LastChangeTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategory _category;

        public NoteCategory Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
                LastChangeTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _text;

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                LastChangeTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Время создания заметки.
        /// </summary>
        private DateTime _creationTime;

        public DateTime CreationTime
        {
            get
            {
                return _creationTime;
            }

            private set
            {
                _creationTime = value;
            }
        }

        /// <summary>
        /// Время последнего изменения заметки.
        /// </summary>
        private DateTime _lastChangeTime;

        public DateTime LastChangeTime
        {
            get
            {
                return _lastChangeTime;
            }

            private set
            {
                _lastChangeTime = value;
            }
        }

        public Note(string name, NoteCategory category, string text)
        {
            Name = name;
            Category = category;
            Text = text;
            CreationTime = DateTime.Now;
            LastChangeTime = DateTime.Now;
        }

        /// <summary>
        /// Метод для создания копии объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}