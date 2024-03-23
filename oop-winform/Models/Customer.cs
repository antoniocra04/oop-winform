using oop_winform.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Collections.Generic;
using System.Net;

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
        /// Адрес покупателя.
        /// </summary>
        private string _address;

        public Customer()
        {
            Address = "";
            FullName = "";
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="fullname">Полное имя. Должно быть не более 200 символов.</param>
        /// <param name="address">Адрес. Должен быть не более 500 символов.</param>
        public Customer(string fullname, string address)
        {
            FullName = fullname;
            Address = address;
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
                ValueValidator.StringLengthCheck(value, 200, nameof(_fullname));
                _fullname = value;
            }
        }

        /// <summary>
        /// Возвращает и задает адрес покупателя.
        /// </summary>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                ValueValidator.StringLengthCheck(value, 500, nameof(_address));
                _address = value;
            }
        }
    }
}
