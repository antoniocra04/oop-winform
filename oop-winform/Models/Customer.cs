using oop_winform.Services;
using System.Collections.Generic;
using oop_winform.Models.Orders;

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
        /// Статус покупателя.
        /// </summary>
        private bool _isPriority;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Customer"/>.
        /// </summary>
        public Customer()
        {
            Address = new Address();
            FullName = "";
            IsPriority= false;
            Discounts = new List<IDiscount>();
            Discounts.Add(new PointsDiscount());
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
            Discounts = new List<IDiscount>();
            Discounts.Add(new PointsDiscount());
        }

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Возвращает и задает полное имя покупателя.
        /// </summary>
        public string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                ValueValidator.StringLengthCheck(value, 200, 1, nameof(_fullname));
                _fullname = value;
            }
        }

        /// <summary>
        /// Возвращает и задает адрес покупателя.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Возвращает и задает корзину покупателя.
        /// </summary>
        public Cart Cart { get; set; } = new Cart();

        /// <summary>
        /// Возвращает и задает список заказов покупателя.
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Возвращает и задает статус покупателя.
        /// </summary>
        public bool IsPriority
        {
            get => _isPriority;
            set => _isPriority = value;
        }

        /// <summary>
        /// Возвращает и задает скидки покупателя.
        /// </summary>
        public List<IDiscount> Discounts { get; set; }
    }
}
