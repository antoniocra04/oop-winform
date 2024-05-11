using oop_winform.Services;
using System.Collections.Generic;

namespace oop_winform.Models
{
    /// <summary>
    /// Хранит данные о покупателе.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Id покупателя.
        /// </summary>
        private readonly int _id = IdGenerator.GetId();

        /// <summary>
        /// Имя покупателя.
        /// </summary>
        private string _fullname;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Customer"/>.
        /// </summary>
        public Customer()
        {
            FullName = "";
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="fullname">Полное имя. Должно быть не более 200 символов.</param>
        /// <param name="address">Адрес. Должен быть не более 500 символов.</param>
        public Customer(string fullname, Address address)
        {
            FullName = fullname;
            Address = address;
        }

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id
        {
            get => _id;
        }

        /// <summary>
        /// Возвращает и задает полное имя покупателя.
        /// </summary>
        public string FullName
        {
            get => _fullname;
            set
            {
                ValueValidator.StringLengthCheck(value, 200, 1, nameof(_fullname));
                _fullname = value;
            }
        }

        /// <summary>
        /// Возвращает и задает адрес покупателя.
        /// </summary>
        public Address Address { get; set; } = new Address();

        /// <summary>
        /// Возвращает и задает корзину покупателя.
        /// </summary>
        public Cart Cart { get; set; } = new Cart();

        /// <summary>
        /// Возвращает и задает список заказов покупателя.
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Возвращает и задает булево значение о том, является ли покупатель приоритетным.
        /// </summary>
        public bool IsPriority { get; set; } = false;
    }
}
