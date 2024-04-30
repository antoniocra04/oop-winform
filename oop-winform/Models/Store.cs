using oop_winform.Services;
using System.Collections.Generic;
﻿using System.Collections.Generic;

namespace oop_winform.Models
{
    /// <summary>
    /// Хранит данные о товарах и покупателях.
    /// </summary>
    public class Store
    {

        /// <summary>
        /// Возвращает и задает список товаров класса <see cref="Item"/>.
        /// </summary>
        public List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Возвращает и задает список покупателей класса <see cref="Customer"/>.
        /// </summary>
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
