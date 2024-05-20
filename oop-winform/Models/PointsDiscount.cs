using oop_winform.Services;
using System.Collections.Generic;
using System;

namespace oop_winform.Models
{
    /// <summary>
    /// Хранит данные о накопительных баллах.
    /// </summary>
    public class PointsDiscount : IDiscount
    {
        /// <summary>
        /// Накопительные баллы.
        /// </summary>
        private int _points;

        /// <summary>
        /// Создает экземпляр класса <see cref="PointsDiscount"/>.
        /// </summary>
        /// <param name="points">Размер накопительных баллов.</param>
        private PointsDiscount(int points)
        {
            Points = points;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="PointsDiscount"/>.
        /// </summary>
        public PointsDiscount()
        {
            Points = 0;
        }

        /// <summary>
        /// Возвращает и задает накопительные баллы.
        /// </summary>
        public int Points
        {
            get => _points;
            private set
            {
                ValueValidator.CheckDigitOnLowLimit(value, 0, nameof(Points));
                _points = value;
            }
        }

        /// <summary>
        /// Возвращает информацию о скидке.
        /// </summary>
        public string Info
        {
            get
            {
                return $"Накопительная - {Points} баллов";
            }
        }

        /// <summary>
        /// Вычисляет размер скидки, доступный для списка товаров.
        /// Скидка товаров не может быть больше 30% от общей суммы товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public double Calculate(List<Item> items)
        {
            var amount = 0f;

            foreach (var item in items)
            {
                amount += item.Cost;
            }

            if (Points / amount > 0.3)
            {
                return amount * 0.3;
            }
            else
            {
                return Points;
            }
        }

        /// <summary>
        /// Применяет накопительные баллы.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public double Apply(List<Item> items)
        {
            var discount = Calculate(items);
            Points -= (int)discount;
            return discount;
        }

        /// <summary>
        /// Обновляет баллы.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        public void Update(List<Item> items)
        {
            var amount = 0f;

            foreach (var item in items)
            {
                amount += item.Cost;
            }
            Points += (int)Math.Ceiling(amount * 0.1);
        }
    }
}
