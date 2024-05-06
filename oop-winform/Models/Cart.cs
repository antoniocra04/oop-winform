using System.Collections.Generic;

namespace oop_winform.Models
{
    /// <summary>
    /// Описывает корзину товаров.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Возвращает и задает cписок товаров в корзине.
        /// </summary>
        public List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Возвращает общую стоимость товаров.
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
