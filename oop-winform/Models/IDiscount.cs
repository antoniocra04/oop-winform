using System.Collections.Generic;

namespace oop_winform.Models
{
    /// <summary>
    /// Интерфейс скидок.
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// Возвращает информацию о скидке.
        /// </summary>
        string Info { get; }

        /// <summary>
        /// Вычисляет размер скидки.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        double Calculate(List<Item> items);

        /// <summary>
        /// Применяет скидку.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        double Apply(List<Item> items);

        /// <summary>
        /// Обновляет скидку.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        void Update(List<Item> items);
    }
}
