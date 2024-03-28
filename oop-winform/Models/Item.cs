﻿using oop_winform.Services;
using System;

namespace oop_winform.Models
{
    /// <summary>
    /// Хранит данные о товаре.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Id товара.
        /// </summary>
        private readonly int _id = IdGenerator.GetId();

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
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Item"/>.
        /// </summary>
        /// <param name="name">Имя продукта.</param>
        /// <param name="info">Информация продукта.</param>
        /// <param name="cost">Цена продукта.</param>
        public Item(string name, string info, float cost)
        {
            Name = name;
            Info = info;
            Cost = cost;
        }

        /// <summary>
        /// Возвращает Id товара.
        /// </summary>
        public int Id 
        { 
            get 
            { 
                return _id; 
            } 
        }

        /// <summary>
        /// Возвращает и задает наименование товара.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                ValueValidator.StringLengthCheck(value, 200, nameof(_name));
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задает информацию о товаре.
        /// </summary>
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                ValueValidator.StringLengthCheck(value, 1000, nameof(_info));
                _info = value;
            }
        }

        /// <summary>
        /// Возвращает и задает цену товара.
        /// </summary>
        public float Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                ValueValidator.FloatLimitCheck(value, 1, 100000, nameof(_cost));
                _cost = value;
            }
        }
    }
}
