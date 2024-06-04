using oop_winform.Services;
using System;
﻿using oop_winform.Models.Enums;
using oop_winform.Models.Orders;

namespace oop_winform.Models
{
    /// <summary>
    /// Хранит данные о товаре.
    /// </summary>
    public class Item : ICloneable, IEquatable<Item>, IComparable<Item>
    {
        /// <summary>
        /// Id товара.
        /// </summary>
        private int _id = IdGenerator.GetId();

        /// <summary>
        /// Название товара.
        /// </summary>
        private string _name;

        /// <summary>
        /// Информация о товаре.
        /// </summary>
        private string _info;

        /// <summary>
        /// Стоимость товара.
        /// </summary>
        private float _cost;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Item"/>.
        /// </summary>
        public Item()
        {
            Name = "";
            Info = "";
            Cost = 0;
            Category = CategoryTypes.Food;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Item"/>.
        /// </summary>
        /// <param name="name">Имя продукта.</param>
        /// <param name="info">Информация продукта.</param>
        /// <param name="cost">Цена продукта.</param>
        /// <param name="category">Категория продукта.</param>
        public Item(string name, string info, float cost, CategoryTypes category)
        {
            Name = name;
            Info = info;
            Cost = cost;
            Category = category;
        }

        /// <summary>
        /// Возвращает и задает категорию товара <see cref="Item"/>.
        /// </summary>
        public CategoryTypes Category { get; set; }

        /// <summary>
        /// Возвращает Id товара.
        /// </summary>
        public int Id 
        {
            get => _id;
            private set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Возвращает и задает наименование товара.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                ValueValidator.StringLengthCheck(value, 200, 1, nameof(_name));
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задает информацию о товаре.
        /// </summary>
        public string Info
        {
            get => _info;
            set
            {
                ValueValidator.StringLengthCheck(value, 1000, 0, nameof(_name));
                _info = value;
            }
        }

        /// <summary>
        /// Возвращает и задает цену товара.
        /// </summary>
        public float Cost
        {
            get => _cost;
            set
            {
                ValueValidator.FloatLimitCheck(value, 1, 100000, nameof(_cost));
                _cost = value;
            }
        }


        /// <summary>
        /// Создает копию объекта <see cref="Item"/>.
        /// </summary>
        /// <returns>Копия объекта.</returns>
        public object Clone()
        {
            return new Item
            {
                Id = Id,
                Name = Name,
                Info = Info,
                Cost = Cost,
                Category = Category
            };
        }

        /// <summary>
        /// Проверка на равенство объекта с передаваемым.
        /// </summary>
        /// <param name="subject">Объект класса <see cref="Item"/>.</param>
        /// <returns>Равны ли объекты.</returns>
        public bool Equals(Item subject)
        {
            if (subject == null) return false;
            if (ReferenceEquals(this, subject)) return true;
            return
                Id == subject.Id &&
                Name == subject.Name &&
                Info == subject.Info &&
                Cost == subject.Cost &&
                Category == subject.Category;
        }

        /// <summary>
        /// Проверка на равенство объекта с передаваемым.
        /// </summary>
        /// <param name="subject">Объект класса.</param>
        /// <returns>Равны ли объекты.</returns>
        public override bool Equals(object subject)
        {
            if (subject == null) return false;
            if (ReferenceEquals(this, subject)) return true;
            return Equals((Item)subject);
        }

        /// <summary>
        /// Сравнивает цену.
        /// </summary>
        /// <param name="subject">Объект класса <see cref="Item"/>.</param>
        /// <returns>0 - цены равны, 1 - цена меньше, -1 - цена больше.</returns>
        public int CompareTo(Item subject)
        {
            if (subject == null) return 1;
            if (ReferenceEquals(this, subject)) return 0;
            else return _cost.CompareTo(subject.Cost);
        }
    }
}
