using oop_winform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_winform.Services
{
    public class DataTools
    {
        /// <summary>
        /// Делегат сравнения товаров по критерию.
        /// </summary>
        /// <param name="first">Товар 1.</param>
        /// <param name="second">Товар 2.</param>
        /// <returns>Менять ли товары местами.</returns>
        public delegate bool CompareCriteria(Item first, Item second);

        /// <summary>
        /// Фильтрация товаров по критерию.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <param name="criteria">Критерий.</param>
        /// <returns>Фильтрованный список товаров.</returns>
        public static List<Item> FilterItems(List<Item> items, Predicate<Item> criteria)
        {
            var filteredItems = new List<Item>();

            foreach (var item in items)
            {
                if (criteria(item))
                {
                    filteredItems.Add(item);
                }
            }

            return filteredItems;
        }

        /// <summary>
        /// Сортировка товаров по заданному методу критерия.
        /// </summary>
        /// <param name="items">Список товаров <see cref="List{Item}"/>.</param>
        /// <param name="compare">Метод критерия <see cref="CompareCriteria"/>.</param>
        /// <returns>Отсортированный список товаров.</returns>
        public static List<Item> SortItems(List<Item> items, CompareCriteria compare)
        {
            var sortedItems = new List<Item>(items);

            for (var i = 0; i < sortedItems.Count; i++)
            {
                for (var j = 0; j < sortedItems.Count; j++)
                {
                    if (compare(sortedItems[i], sortedItems[j]))
                    {
                        var item = sortedItems[i];
                        sortedItems[i] = sortedItems[j];
                        sortedItems[j] = item;
                    }
                }
            }

            return sortedItems;
        }
    }
}
