using oop_winform.Models;
using oop_winform.Services;
using System;
using System.Windows.Forms;

namespace oop_winform.View.Controls
{
    /// <summary>
    /// Управляет логикой работы с полями адреса.
    /// </summary>
    public partial class AddressControl : UserControl
    {
        /// <summary>
        /// Адрес.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Создает экземпляр класса <see cref="AddressControl"/>.
        /// </summary>
        public AddressControl()
        {
            InitializeComponent();
            Address = null;
        }

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
        /// Возвращает и задает активность элементов.
        /// </summary>
        private bool IsEnabled { get; set; }

        /// <summary>
        /// Установка корректных данных в тексбоксах.
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

            PostIndexTextBox.Text = IsEnabled ? Address.Index.ToString() : "";
            CountryTextBox.Text = IsEnabled ? Address.Country.ToString() : "";
            CityTextBox.Text = IsEnabled ? Address.City.ToString() : "";
            StreetTextBox.Text = IsEnabled ? Address.Street.ToString() : "";
            BuildingTextBox.Text = IsEnabled ? Address.Building.ToString() : "";
            ApartmentTextBox.Text = IsEnabled ? Address.Apartment.ToString() : "";
        }

        private void PostIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var index = Convert.ToInt32(PostIndexTextBox.Text);
                Address.Index = index;
            }
            catch(ArgumentException exeption)
            {
                PostIndexTextBox.BackColor = Constants.ErrorColor;
                return;
            }
            catch (Exception ex)
            {
                PostIndexTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            PostIndexTextBox.BackColor = Constants.CorrectColor;
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Country = CountryTextBox.Text;
            }
            catch (ArgumentException exeption)
            {
                CountryTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            CountryTextBox.BackColor = Constants.CorrectColor;
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.City = CityTextBox.Text;
            }
            catch (ArgumentException exeption)
            {
                CityTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            CityTextBox.BackColor = Constants.CorrectColor;
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            try
                {
                    Address.Street = StreetTextBox.Text;
                }
            catch (ArgumentException exeption)
                {
                    StreetTextBox.BackColor = Constants.ErrorColor;
                    return;
                }

            StreetTextBox.BackColor = Constants.CorrectColor;
        }

        private void BuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Building = BuildingTextBox.Text;
            }
            catch (ArgumentException exeption)
            {
                BuildingTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            BuildingTextBox.BackColor = Constants.CorrectColor;
        }

        private void ApartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Apartment = ApartmentTextBox.Text;
            }
            catch (ArgumentException exeption)
            {
                ApartmentTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            ApartmentTextBox.BackColor = Constants.CorrectColor;
        }
    }
}
