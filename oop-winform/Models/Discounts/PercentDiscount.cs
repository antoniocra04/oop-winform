using oop_winform.Services;
using System;
﻿using oop_winform.Models.Enums;
using System.Collections.Generic;

namespace oop_winform.Models.Discounts
{
    /// <summary>
    /// Хранит процентную скидку.
    /// </summary>
    public class PercentDiscount : IDiscount, IComparable<PercentDiscount>
    {
        /// <summary>
        /// Скидка в процентах.
        /// </summary>
        private int _discount;

        /// <summary>
        /// Создает экземпляр класса <see cref="PercentDiscount"/>.
        /// </summary>
        /// <param name="category">Скидочная категория</param>
        public PercentDiscount(CategoryTypes category)
        {
            Category = category;
            Discount = 1;
        }

        /// <summary>
        /// Возвращает и задает скидку в процентах.
        /// </summary>
        public int Discount
        {
            get => _discount;
            private set
            {
                ValueValidator.CheckLimitInInt(value, 1, 10, nameof(Discount));
                _discount = value;
            }
        }

        /// <summary>
        /// Возвращает скидочную категорию.
        /// </summary>
        public CategoryTypes Category { get; }

        /// <summary>
        /// Возвращает и задает сумму которую потратил покупатель в данной категории.
        /// </summary>
        public double SpendingPerCategory { get; private set; } = 0;

        /// <summary>
        /// Возвращает информацию о скидке.
        /// </summary>
        public string Info
        {
            get
            {
                return $"Процентная \"{Category}\" - {Discount}%";
            }
        }

        /// <summary>
        /// Вычисляет размер скидки для товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public double Calculate(List<Item> items)
        {
            var amount = 0f;
            foreach (var item in items)
            {
                if (item.Category == Category)
                {
                    amount += item.Cost;
                }
            }
            return amount * Discount / 100;
        }

        /// <summary>
        /// Применяет скидку, доступную для списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public double Apply(List<Item> items)
        {
            return Calculate(items);
        }

        /// <summary>
        /// Обновляет процент скидки на основе полученного списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        public void Update(List<Item> items)
        {
            var amount = 0f;
            foreach (var item in items)
            {
                if (item.Category == Category)
                {
                    amount += item.Cost;
                }
            }
            SpendingPerCategory += amount;
            var percentage = (int)(SpendingPerCategory / 1000) + 1;

            if (percentage > 10)
            {
                Discount = 10;
            }
            else
            {
                Discount = percentage;
            }
        }

        /// <summary>
        /// Сравнивает исходный объект с передаваемым.
        /// </summary>
        /// <param name="subject">Объект класса <see cref="PercentDiscount"/>.</param>
        /// <returns>0 - проценты равны, 1 - процентов меньше, -1 - процентов больше.</returns>
        public int CompareTo(PercentDiscount subject)
        {
            if (ReferenceEquals(this, subject)) return 0;
            if (ReferenceEquals(null, subject)) return 1;
            else return _discount.CompareTo(subject);
        }
    }
}
