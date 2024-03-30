﻿using oop_winform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_winform.Models
{
    internal class Address
    {
        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        private int _index;

        /// <summary>
        /// Страна.
        /// </summary>
        private string _country;

        /// <summary>
        /// Город.
        /// </summary>
        private string _city;

        /// <summary>
        /// Улица.
        /// </summary>
        private string _street;

        /// <summary>
        /// Номер здания.
        /// </summary>
        private string _building;

        /// <summary>
        /// Номер квартиры/помещения.
        /// </summary>
        private string _apartment;

        /// <summary>
        /// Создает экзепляр класса <see cref="Address"/>.
        /// </summary>
        public Address()
        {
            Index = 000000;
            Country = "";
            City = "";
            Street = "";
            Building = "";
            Apartment = "";
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Address"/>.
        /// </summary>
        /// <param name="index">Почтовый индекс.</param>
        /// <param name="country">Страна.</param>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="building">Номер дома.</param>
        /// <param name="apartment">Номер квартиры.</param>
        public Address(
            int index,
            string country,
            string city,
            string street,
            string building,
            string apartment)
        {
            Index = index;
            Country = country;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
        }

        /// <summary>
        /// Возвращает и задает почтовый индекс.
        /// </summary>
        public int Index
        {
            get => _index;
            set
            {
                ValueValidator.CheckDigitsInInt(value, 6, nameof(Index));
                _index = value;
            }
        }

        /// <summary>
        /// Возвращает и задает страну.
        /// </summary>
        public string Country
        {
            get => _country;
            set
            {
                ValueValidator.StringLengthCheck(value, 50, nameof(Country));
                _country = value;
            }
        }

        /// <summary>
        /// Возвращает и задает город.
        /// </summary>
        public string City
        {
            get => _city;
            set
            {
                ValueValidator.StringLengthCheck(value, 50, nameof(City));
                _city = value;
            }
        }

        /// <summary>
        /// Возвращает и задает улицу.
        /// </summary>
        public string Street
        {
            get => _street;
            set
            {
                ValueValidator.StringLengthCheck(value, 100, nameof(Street));
                _street = value;
            }
        }

        /// <summary>
        /// Возвращает и задает номер здания.
        /// </summary>
        public string Building
        {
            get => _building;
            set
            {
                ValueValidator.StringLengthCheck(value, 10, nameof(Building));
                _building = value;
            }
        }

        /// <summary>
        /// Возвращает и задает номер квартиры/помещения.
        /// </summary>
        public string Apartment
        {
            get => _apartment;
            set
            {
                ValueValidator.StringLengthCheck(value, 10, nameof(Apartment));
                _apartment = value;
            }
        }
    }
}