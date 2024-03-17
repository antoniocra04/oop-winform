using oop_winform.Services;

namespace oop_winform.Models
{
    /// <summary>
    /// Хранит данные о покупателе.
    /// </summary>
    internal class Customer
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
        /// Возвращает и задает Id адреса покупателя.
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
