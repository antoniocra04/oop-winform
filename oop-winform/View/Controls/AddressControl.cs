using oop_winform.Models;
using oop_winform.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace oop_winform.View.Controls
{
    public partial class AddressControl : UserControl
    {
        /// <summary>
        /// Адрес.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Возвращает и задает адрес.
        /// </summary>
        public Address Address
        {
            get => _address;

            set
            {
                _address = value;
                SetValuesTextBoxes();
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="AddressControl"/>.
        /// </summary>
        public AddressControl()
        {
            InitializeComponent();
            Address = null;
        }

        /// <summary>
        /// Активность элементов.
        /// </summary>
        private bool IsEnabled { get; set; }

        /// <summary>
        /// Устанавливает 
        /// </summary>
        private void SetValuesTextBoxes()
        {
            IsEnabled = Address != null;
            PostIndexTextBox.Enabled = IsEnabled;
            CountryTextBox.Enabled = IsEnabled;
            CityTextBox.Enabled = IsEnabled;
            StreetTextBox.Enabled = IsEnabled;
            BuildingTextBox.Enabled = IsEnabled;
            ApartmentTextBox.Enabled = IsEnabled;

            if (IsEnabled)
            {
                PostIndexTextBox.Text = Address.Index.ToString();
                CountryTextBox.Text = Address.Country;
                CityTextBox.Text = Address.City;
                StreetTextBox.Text = Address.Street;
                BuildingTextBox.Text = Address.Building;
                ApartmentTextBox.Text = Address.Apartment;
            }
            else
            {
                PostIndexTextBox.Text = "";
                CountryTextBox.Text = "";
                CityTextBox.Text = "";
                StreetTextBox.Text = "";
                BuildingTextBox.Text = "";
                ApartmentTextBox.Text = "";
            }
        }

        public void Clear()
        {
            PostIndexTextBox.Clear();
            CountryTextBox.Clear();
            CityTextBox.Clear();
            StreetTextBox.Clear();
            BuildingTextBox.Clear();
            ApartmentTextBox.Clear();

            PostIndexTextBox.BackColor = Constants.CorrectColor;
        }

        private void PostIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(PostIndexTextBox.Text);
                _address.Index = index;
            }
            catch(ArgumentException exeption)
            {
                PostIndexTextBox.BackColor = Constants.ErrorColor;
                return;
            }
            catch { }

            PostIndexTextBox.BackColor = Constants.CorrectColor;
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            if(_address != null)
            {
                try
                {
                    _address.Country = CountryTextBox.Text;
                }
                catch (ArgumentException exeption)
                {
                    CountryTextBox.BackColor = Constants.ErrorColor;
                    return;
                }
            }

            CountryTextBox.BackColor = Constants.CorrectColor;
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_address != null)
            {
                try
                {
                    _address.City = CityTextBox.Text;
                }
                catch (ArgumentException exeption)
                {
                    CityTextBox.BackColor = Constants.ErrorColor;
                    return;
                }
            }

            CityTextBox.BackColor = Constants.CorrectColor;
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_address != null)
            {
                try
                {
                    _address.Street = StreetTextBox.Text;
                }
                catch (ArgumentException exeption)
                {
                    StreetTextBox.BackColor = Constants.ErrorColor;
                    return;
                }
            }

            StreetTextBox.BackColor = Constants.CorrectColor;
        }

        private void BuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_address != null)
            {
                try
                {
                    _address.Building = BuildingTextBox.Text;
                }
                catch (ArgumentException exeption)
                {
                    BuildingTextBox.BackColor = Constants.ErrorColor;
                    return;
                }
            }

            BuildingTextBox.BackColor = Constants.CorrectColor;
        }

        private void ApartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_address != null)
            {
                try
                {
                    _address.Apartment = ApartmentTextBox.Text;
                }
                catch (ArgumentException exeption)
                {
                    ApartmentTextBox.BackColor = Constants.ErrorColor;
                    return;
                }
            }

            ApartmentTextBox.BackColor = Constants.CorrectColor;
        }
    }
}
