﻿using System;
using System.Collections.Generic;
using oop_winform.Services;

namespace oop_winform.Models
{
    /// <summary>
    /// Хранит данные о заказе.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id заказа.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Дата создания заказа.
        /// </summary>
        private readonly DateTime _date = DateTime.Now;

        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>.
        /// </summary>
        public Order()
        {
            _id = IdGenerator.GetId();
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Список товаров заказа.</param>
        public Order(OrderStatusTypes status, Address address, List<Item> items)
        {
            _id = IdGenerator.GetId();
            Status = status;
            Address = address;
            Items = items;
        }

        /// <summary>
        /// Возвращает уникальный индентификатор заказа.
        /// </summary>
        public int Id
        {
            get => _id;
        }

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public DateTime CreationDate
        {
            get => _date;
        }

        /// <summary>
        /// Возвращает и задает статус заказа.
        /// </summary>
        public OrderStatusTypes Status { get; set; } = OrderStatusTypes.New;

        /// <summary>
        /// Возращает и задает адрес доставки.
        /// </summary>
        public Address Address { get; set; } = new Address();

        /// <summary>
        /// Возращает и задает адрес доставки.
        /// </summary>
        public List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Возвращает общую стоимость товаров в заказе.
        /// </summary>
        public float Amount
        {
            get
            {
                if (Items == null)
                {
                    return 0;
                }

                float total = 0;

                foreach (var item in Items)
                {
                    total += item.Cost;
                }

                return total;
            }
        }
    }
}
