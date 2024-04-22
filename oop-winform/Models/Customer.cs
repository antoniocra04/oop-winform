using oop_winform.Services;

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
            Address = new Address();
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
        /// Возвращает и задает адрес покупателя.
        /// </summary>
        public Address Address { get; set; }

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
    }
}
